using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Comparison.WebForms.Products.Common.Entity.Web;
using GroupDocs.Comparison.WebForms.Products.Comparison.Model.Response;
using GroupDocs.Comparison.WebForms.Products.Common.Config;
using GroupDocs.Comparison.WebForms.Products.Common.Util.Comparator;
using GroupDocs.Comparison.WebForms.Products.Comparison.Model.Request;
using GroupDocs.Comparison.Interfaces;
using GroupDocs.Comparison.Options;
using GroupDocs.Comparison.Result;

namespace GroupDocs.Comparison.WebForms.Products.Comparison.Service
{
    public class ComparisonServiceImpl : IComparisonService
    {
        private readonly GlobalConfiguration globalConfiguration;

        public ComparisonServiceImpl(GlobalConfiguration globalConfiguration)
        {
            this.globalConfiguration = globalConfiguration;
        }

        public List<FileDescriptionEntity> LoadFiles(PostedDataEntity fileTreeRequest)
        {
            // get request body
            string relDirPath = fileTreeRequest.path;
            // get file list from storage path
            try
            {
                // get all the files from a directory
                if (string.IsNullOrEmpty(relDirPath))
                {
                    relDirPath = globalConfiguration.Comparison.GetFilesDirectory();
                }
                else
                {
                    relDirPath = Path.Combine(globalConfiguration.Comparison.GetFilesDirectory(), relDirPath);
                }

                List<string> allFiles = new List<string>(Directory.GetFiles(relDirPath));
                allFiles.AddRange(Directory.GetDirectories(relDirPath));
                List<FileDescriptionEntity> fileList = new List<FileDescriptionEntity>();

                allFiles.Sort(new FileNameComparator());
                allFiles.Sort(new FileTypeComparator());

                foreach (string file in allFiles)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                    // check if current file/folder is hidden
                    if (!(fileInfo.Attributes.HasFlag(FileAttributes.Hidden) ||
                        Path.GetFileName(file).StartsWith(".") ||
                        Path.GetFileName(file).Equals(Path.GetFileName(globalConfiguration.Comparison.GetFilesDirectory())) ||
                        Path.GetFileName(file).Equals(Path.GetFileName(globalConfiguration.Comparison.GetResultDirectory()))))
                    {
                        FileDescriptionEntity fileDescription = new FileDescriptionEntity
                        {
                            guid = Path.GetFullPath(file),
                            name = Path.GetFileName(file),
                            // set is directory true/false
                            isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        };
                        // set file size
                        if (!fileDescription.isDirectory)
                        {
                            fileDescription.size = fileInfo.Length;
                        }
                        // add object to array list
                        fileList.Add(fileDescription);
                    }
                }
                return fileList;
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Exception occurred while loading files", ex);
            }
        }

        public bool CheckFiles(CompareRequest files)
        {
            string extension = Path.GetExtension(files.guids[0].GetGuid());
            // check if files extensions are the same and support format file
            if (!CheckSupportedFiles(extension))
            {
                return false;
            }
            foreach (CompareFileDataRequest path in files.guids)
            {
                if (!extension.Equals(Path.GetExtension(path.GetGuid())))
                {
                    return false;
                }
            }
            return true;
        }

        public CompareResultResponse Compare(CompareRequest compareRequest)
        {
            CompareResultResponse compareResultResponse = CompareTwoDocuments(compareRequest);
            return compareResultResponse;
        }

        public static LoadDocumentEntity LoadDocumentPages(string documentGuid, string password, bool loadAllPages)
        {
            LoadDocumentEntity loadDocumentEntity = new LoadDocumentEntity();

            using (Comparer comparer = new Comparer(documentGuid, GetLoadOptions(password)))
            {
                Dictionary<int, string> pagesContent = new Dictionary<int, string>();
                IDocumentInfo documentInfo = comparer.Source.GetDocumentInfo();

                if (documentInfo.PagesInfo == null)
                {
                    throw new GroupDocs.Comparison.Common.Exceptions.ComparisonException("File is corrupted.");
                }

                if (loadAllPages)
                {
                    for (int i = 0; i < documentInfo.PageCount; i++)
                    {
                        string encodedImage = GetPageData(i, documentGuid, password);

                        pagesContent.Add(i, encodedImage);
                    }
                }

                for (int i = 0; i < documentInfo.PageCount; i++)
                {
                    PageDescriptionEntity pageData = new PageDescriptionEntity
                    {
                        height = documentInfo.PagesInfo[i].Height,
                        width = documentInfo.PagesInfo[i].Width,
                        number = i + 1
                    };

                    if (pagesContent.Count > 0)
                    {
                        pageData.SetData(pagesContent[i]);
                    }

                    loadDocumentEntity.SetPages(pageData);
                }

                return loadDocumentEntity;
            }
        }

        public PageDescriptionEntity LoadDocumentPage(PostedDataEntity postedData)
        {
            PageDescriptionEntity loadedPage = new PageDescriptionEntity();

            try
            {
                // get/set parameters
                string documentGuid = postedData.guid;
                int pageNumber = postedData.page;
                string password = string.IsNullOrEmpty(postedData.password) ? null : postedData.password;

                using (Comparer comparer = new Comparer(documentGuid, GetLoadOptions(password)))
                {
                    IDocumentInfo info = comparer.Source.GetDocumentInfo();

                    string encodedImage = GetPageData(pageNumber - 1, documentGuid, password);
                    loadedPage.SetData(encodedImage);

                    loadedPage.height = info.PagesInfo[pageNumber - 1].Height;
                    loadedPage.width = info.PagesInfo[pageNumber - 1].Width;
                    loadedPage.number = pageNumber;
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Exception occurred while loading result page", ex);
            }

            return loadedPage;
        }

        private static string GetPageData(int pageNumber, string documentGuid, string password)
        {
            string encodedImage = "";

            using (Comparer comparer = new Comparer(documentGuid, GetLoadOptions(password)))
            {
                byte[] bytes = RenderPageToMemoryStream(comparer, pageNumber).ToArray();
                encodedImage = Convert.ToBase64String(bytes);
            }

            return encodedImage;
        }

        static MemoryStream RenderPageToMemoryStream(Comparer comparer, int pageNumberToRender)
        {
            MemoryStream result = new MemoryStream();
            IDocumentInfo documentInfo = comparer.Source.GetDocumentInfo();

            PreviewOptions previewOptions = new PreviewOptions(pageNumber => result)
            {
                PreviewFormat = PreviewFormats.PNG,
                PageNumbers = new[] { pageNumberToRender + 1 },
                Height = documentInfo.PagesInfo[pageNumberToRender].Height,
                Width = documentInfo.PagesInfo[pageNumberToRender].Width
            };

            comparer.Source.GeneratePreview(previewOptions);

            return result;
        }

        private static LoadOptions GetLoadOptions(string password)
        {
            LoadOptions loadOptions = new LoadOptions
            {
                Password = password
            };

            return loadOptions;
        }

        private CompareResultResponse CompareTwoDocuments(CompareRequest compareRequest)
        {
            // to get correct coordinates we will compare document twice
            // this is a first comparing to get correct coordinates of the insertions and style changes
            string extension = Path.GetExtension(compareRequest.guids[0].GetGuid());
            string guid = Guid.NewGuid().ToString();
            //save all results in file
            string resultGuid = Path.Combine(globalConfiguration.Comparison.GetResultDirectory(), guid + extension);

            Comparer compareResult = CompareFiles(compareRequest, resultGuid);
            ChangeInfo[] changes = compareResult.GetChanges();

            CompareResultResponse compareResultResponse = GetCompareResultResponse(changes, resultGuid);
            compareResultResponse.SetExtension(extension);
            return compareResultResponse;
        }

        private static Comparer CompareFiles(CompareRequest compareRequest, string resultGuid)
        {
            string firstPath = compareRequest.guids[0].GetGuid();
            string secondPath = compareRequest.guids[1].GetGuid();

            // create new comparer
            Comparer comparer = new Comparer(firstPath, GetLoadOptions(compareRequest.guids[0].GetPassword()));

            comparer.Add(secondPath, GetLoadOptions(compareRequest.guids[1].GetPassword()));
            CompareOptions compareOptions = new CompareOptions { CalculateCoordinates = true };

            if (Path.GetExtension(resultGuid) == ".pdf")
            {
                compareOptions.DetalisationLevel = DetalisationLevel.High;
            }

            using (FileStream outputStream = File.Create(Path.Combine(resultGuid)))
            {
                comparer.Compare(outputStream, compareOptions);
            }

            return comparer;
        }

        private static CompareResultResponse GetCompareResultResponse(ChangeInfo[] changes, string resultGuid)
        {
            CompareResultResponse compareResultResponse = new CompareResultResponse();
            compareResultResponse.SetChanges(changes);

            List<PageDescriptionEntity> pages = LoadDocumentPages(resultGuid, "", true).GetPages();

            compareResultResponse.SetPages(pages);
            compareResultResponse.SetGuid(resultGuid);
            return compareResultResponse;
        }

        /// <summary>
        /// Check support formats for comparing
        /// </summary>
        /// <param name="extension"></param>
        /// <returns>string</returns>
        private bool CheckSupportedFiles(string extension)
        {
            switch (extension)
            {
                case ".doc":
                case ".docx":
                case ".xls":
                case ".xlsx":
                case ".ppt":
                case ".pptx":
                case ".pdf":
                case ".txt":
                case ".html":
                case ".htm":
                case ".jpg":
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
    }
}
