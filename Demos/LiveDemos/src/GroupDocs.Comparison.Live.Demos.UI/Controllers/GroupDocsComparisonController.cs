using System;
using System.IO;
using System.Web.Http;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing.Imaging;
using System.Net;
using GroupDocs.Comparison.Live.Demos.UI.Models;
using GroupDocs.Comparison.Result;
using GroupDocs.Comparison.Options;

namespace GroupDocs.Comparison.Live.Demos.UI.Controllers
{
	public class GroupDocsComparisonController : ApiControllerBase
	{
		[HttpGet]
		[ActionName("DocumentPages")]
		public List<ChangeInfoItem> DocumentPages(string file, string folderName, string file2, string userEmail, int currentPage)
		{
			string logMsg = "Product: Comparison sourceFile: " + file + " targetFile: " + file2 + " CurrentPage: " + currentPage;
			List<ChangeInfoItem> output;

			try
			{
				output = GetDocumentPages(file, folderName, file2, userEmail, currentPage);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		private List<ChangeInfoItem> GetDocumentPages(string file, string folderName, string file2, string userEmail, int currentPage)
		{
			List<ChangeInfoItem> lstOutput = new List<ChangeInfoItem>();
			string outfileName = "{0}result";
			outfileName = "image/{0}";
			string outPath = AppSettings.OutputDirectory + folderName + "/" + outfileName;

			string imagePath = string.Format(outPath, currentPage) + ".png";

			if (!Directory.Exists(AppSettings.OutputDirectory + folderName))
			{
				Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);
			}

			int i = currentPage;

			try
			{
				string resultFile = "Result_" + file2.Replace("Target_", "");
				if (currentPage == 1)
				{
					using (Comparer comparer = new Comparer(AppSettings.WorkingDirectory + folderName + "/" + file))
					{
						comparer.Add(AppSettings.WorkingDirectory + folderName + "/" + file2);
						CompareOptions compareOptions = new CompareOptions()
						{
							DetectStyleChanges = true,
							GenerateSummaryPage = true,
							DetalisationLevel = DetalisationLevel.High,
							HeaderFootersComparison = true
						};

						comparer.Compare(AppSettings.OutputDirectory + folderName + "/" + resultFile, compareOptions);

						int pageCount = 1;
						Document document = new Document(System.IO.File.OpenRead(AppSettings.OutputDirectory + folderName + "/" + resultFile));

						if (!Directory.Exists(AppSettings.OutputDirectory + folderName + "/image/"))
						{
							Directory.CreateDirectory(AppSettings.OutputDirectory + folderName + "/image/");
						}

						PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
						{
							var pagePath = Path.Combine(AppSettings.OutputDirectory + folderName + "/image/", pageNumber + ".png");
							return System.IO.File.Create(pagePath);
						});
						previewOptions.PreviewFormat = PreviewFormats.PNG;
						document.GeneratePreview(previewOptions);

						if (Directory.Exists(AppSettings.OutputDirectory + folderName + "/image"))
							pageCount = Directory.GetFiles(AppSettings.OutputDirectory + folderName + "/image").Length;
						else
							pageCount = 1;

						lstOutput.Add(new ChangeInfoItem(new ChangeInfo(), "count", pageCount.ToString()));
						lstOutput.Add(new ChangeInfoItem(new ChangeInfo(), "page", imagePath));

						var compareChangesInfo = comparer.GetChanges();

						if (compareChangesInfo != null)
						{
							if (compareChangesInfo.Length > 0)
							{
								foreach (ChangeInfo change in compareChangesInfo)
								{
									lstOutput.Add(new ChangeInfoItem(change, change.Type.ToString(), change.ComparisonAction.ToString()));
								}
							}
						}
					}
					return lstOutput;
				}

				lstOutput.Add(new ChangeInfoItem(new ChangeInfo(), "page", imagePath));

				return lstOutput;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpGet]
		[ActionName("DownloadDocument")]
		public HttpResponseMessage DownloadDocument(string file, string folderName, bool isSourceFile, bool isImage)
		{
			file = file.Replace("../", "").Replace("//", "");
			folderName = folderName.Replace("../", "").Replace("//", "");
			string outfileName = Path.GetFileNameWithoutExtension(file) + "_Out.zip";
			string outPath = AppSettings.OutputDirectory + outfileName;
			string parentFolder = Directory.GetParent(System.IO.Path.Combine(AppSettings.WorkingDirectory + folderName + "/" + file, @"..\..")).ToString();

			if (!parentFolder.ToLower().Equals(AppSettings.FilesBaseDirectory))
			{
				throw new Exception("Invalid file path.");
			}

			if (!isImage)
			{
				if (isSourceFile)
					outPath = AppSettings.WorkingDirectory + folderName + "/" + file;
				else
					outPath = AppSettings.OutputDirectory + folderName + "/" + file;
			}
			else
			{
				if (System.IO.File.Exists(outPath))
					System.IO.File.Delete(outPath);

				ZipFile.CreateFromDirectory(AppSettings.OutputDirectory + folderName + "/", outPath);
			}

			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(outPath, FileMode.Open, FileAccess.Read);
			}
			catch (Exception x)
			{
				throw x;
			}
			using (var ms = new MemoryStream())
			{
				fileStream.CopyTo(ms);
				var result = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new ByteArrayContent(ms.ToArray())
				};
				result.Content.Headers.ContentDisposition =
					new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
					{
						FileName = (isImage ? outfileName : file)
					};
				result.Content.Headers.ContentType =
					new MediaTypeHeaderValue("application/octet-stream");

				return result;
			}
		}

		[HttpGet]
		[ActionName("PageImage")]
		public HttpResponseMessage PageImage(string imagePath)
		{
			imagePath = imagePath.Replace("../", "").Replace("//", "");
			return GetImageFromPath(imagePath);
		}

		private HttpResponseMessage GetImageFromPath(string imagePath)
		{
			HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
			FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
			System.Drawing.Image image = System.Drawing.Image.FromStream(fileStream);
			MemoryStream memoryStream = new MemoryStream();


			image.Save(memoryStream, ImageFormat.Jpeg);
			result.Content = new ByteArrayContent(memoryStream.ToArray());

			if (imagePath.Contains(".png"))
				result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
			else
				result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
			fileStream.Close();

			return result;
		}

		[HttpGet]
		[ActionName("GetAllComparisonSupportedFormats")]
		public async Task<Response> GetAllComparisonSupportedFormats()
		{
			try
			{
				string strFromExtensions = "DOC, DOCX, DOT, DOTX, DOCM, DOTM, RTF, XLS, XLSX, XLSM, XLSB, CSV, XLS2003, PPT, PPTX, PPS, PPSX, EML, EMLX, MSG, MHTML, ONE, VSDX, ODT, OTT, ODS, ODP, OTP, PDF, DXF, DWG, JPEG, BMP, PNG, GIF, DCM, DICOM, HTM, HTML, TXT, DjVu,".ToLower();

				strFromExtensions = strFromExtensions.Trim().Trim(',').ToUpper();

				return await Task.FromResult(new Response
				{
					OutputType = strFromExtensions,
					StatusCode = 200
				});
			}
			catch (Exception exc)
			{
				return new Response
				{
					Status = exc.Message,
					StatusCode = 500,
					Text = exc.ToString()
				};
			}
		}

		public class ChangeInfoItem : ChangeInfo
		{
			public string TypeText { get; set; }
			public string ActionText { get; set; }
			public ChangeInfo changeInfo { get; set; }

			public ChangeInfoItem(ChangeInfo objChangeInfo, string typeText, string actionText)
			{
				this.TypeText = typeText;
				this.ActionText = actionText;
				this.changeInfo = objChangeInfo;
			}
		}

	}
}