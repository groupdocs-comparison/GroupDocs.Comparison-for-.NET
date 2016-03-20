using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using GroupDocsComparisonWebFormsDemo.CompareLibrary;

namespace GroupDocsComparisonWebFormsDemo
{
    public class CompareAndDownloadController : ApiController
    {
        [HttpPost]
        public KeyValuePair<bool, string> CompareAndDownloadResults()
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedSourceFile = HttpContext.Current.Request.Files["UploadedSource"];
                    var httpPostedTargetFile = HttpContext.Current.Request.Files["UploadedTarget"];

                    if (httpPostedSourceFile != null && httpPostedTargetFile != null)
                    {
                        // Validate the uploaded file

                        if (Path.GetExtension(httpPostedSourceFile.FileName) == Path.GetExtension(httpPostedTargetFile.FileName))
                        {
                            // vaerify folder path is valid
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/UploadedFiles")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/UploadedFiles"));
                            }

                            // Apply GroupDocs Product License
                            if (File.Exists(HttpContext.Current.Server.MapPath("~/UploadedFiles/GroupDocs.Total.lic")))
                            {
                                // Instantiate GroupDocs.Comparison license
                                GroupDocs.Comparison.Common.License.License license = new GroupDocs.Comparison.Common.License.License();

                                // Apply GroupDocs.Comparison license using license path
                                license.SetLicense(HttpContext.Current.Server.MapPath("~/UploadedFiles/GroupDocs.Total.lic"));
                            }

                            // Output file path 
                            Guid newFileTempname = new Guid();
                            string outputFile = HttpContext.Current.Server.MapPath("~/UploadedFiles") + "/" + newFileTempname.ToString() + Path.GetExtension(httpPostedSourceFile.FileName);

                            // Validate the uploaded file
                            if (Path.GetExtension(httpPostedSourceFile.FileName).Contains("doc"))
                            {
                                outputFile = WordDcumentsComparision.CompareWordDcumentsFromStreamToFile(httpPostedSourceFile.InputStream, httpPostedTargetFile.InputStream, outputFile);
                            }
                            else
                            {
                                return new KeyValuePair<bool, string>(false, "This demo version currently only support (*.doc, *.docx) document comparison using GroupDocs.Comparison for .NET API.");
                            }

                            return new KeyValuePair<bool, string>(true, "/UploadedFiles/" + newFileTempname.ToString() + Path.GetExtension(httpPostedSourceFile.FileName));
                        }
                        else
                        {
                            return new KeyValuePair<bool, string>(false, "Invalid File, Please select valid source & target files to compare.");
                        }
                    }

                    return new KeyValuePair<bool, string>(true, "Could not get the files.");
                }

                return new KeyValuePair<bool, string>(false, "Invalid File, Please select valid source & target files to compare.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, "An error occurred while uploading the file. Error Message: " + ex.Message);
            }
        }
    }
}