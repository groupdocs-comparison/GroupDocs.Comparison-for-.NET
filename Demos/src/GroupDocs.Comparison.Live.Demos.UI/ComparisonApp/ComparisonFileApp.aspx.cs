using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GroupDocs.Comparison.Live.Demos.UI.Models;
using GroupDocs.Comparison.Live.Demos.UI.Config;
using GroupDocs.Comparison.Live.Demos.UI.Helpers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GroupDocs.Comparison.Live.Demos.UI.ComparisonApp
{
	public partial class ComparisonFileApp : BasePage
	{
		public string fileFormat = "";
		public string metatitle = "";
		public string metadescription = "";
		public string metakeywords = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				metatitle = "Free Online Document Comparison";
				metadescription = "Compare your files/documents in seconds. 100% free online document comparison, secure and easy to use! GroupDocs.App — advanced online tool that solving any problems with any files.";
				metakeywords = "Compare documents, compare two documents, compare two files, document comparison tool, file comparison, free online document comparison, ilove, document, 100 free";
				hheading.InnerHtml = metatitle;
				hdescription.InnerHtml = "Fast and Secure Comparison of more than 50 types of documents, from any device with a modern browser like Chrome, Opera and Firefox.";

				string validationExpression = "";
				string validFileExtensions = GetValidFileExtensions(validationExpression);
				string supportedFileExtensions = "";

				if (Page.RouteData.Values["fileformat"] != null)
				{
					if (!Page.RouteData.Values["fileformat"].ToString().ToLower().Equals("total"))
					{
						fileFormat = Page.RouteData.Values["fileformat"].ToString();
						validationExpression = "." + fileFormat.ToLower();
						validFileExtensions = fileFormat;
						supportedFileExtensions = fileFormat;
					}
				}
				else
				{
                    Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                    Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";
                    Response response = GroupDocsComparisonApiHelper.GetAllComparisonSupportedFormats();
					if (response == null)
					{
						throw new Exception(Resources["APIResponseTime"]);
					}
					else if (response.StatusCode == 200)
					{
						if (response.OutputType.Length > 0)
						{
							validationExpression = "." + response.OutputType.Replace(", ", "|.").ToLower();
							validFileExtensions = response.OutputType;
							supportedFileExtensions = response.OutputType;
						}
					}
				}

				ValidateFileType.ValidationExpression = @"(.*?)(" + validationExpression.ToLower() + "|" + validationExpression.ToUpper() + ")$";
				ValidateFileType2.ValidationExpression = @"(.*?)(" + validationExpression.ToLower() + "|" + validationExpression.ToUpper() + ")$";

				int index = supportedFileExtensions.LastIndexOf(",");
				if (index != -1)
				{
					string substr = supportedFileExtensions.Substring(index);
					string str = substr.Replace(",", " or");
					supportedFileExtensions = supportedFileExtensions.Replace(substr, str);
				}

				ValidateFileType.ErrorMessage = Resources["InvalidFileExtension"] + " " + supportedFileExtensions;
				ValidateFileType2.ErrorMessage = Resources["InvalidFileExtension"] + " " + supportedFileExtensions;

				aPoweredBy.InnerText = "GroupDocs.Comparison";
				aPoweredBy.HRef = "https://products.GroupDocs.com/Comparison";

				hFeatureTitle.InnerText = "GroupDocs Comparison App";
				hPageTitle.InnerHtml = "Compare your file online from anywhere";

				hdnAllowedFileTypes.Value = validFileExtensions.ToLower();

				btnCompare.Text = Resources["btnCompareNow"];
				rfvFile.ErrorMessage = Resources["SelectorDropFileMessage"];
				rfvFile2.ErrorMessage = Resources["SelectorDropFileMessage"];
				h4para.InnerText = string.Format(Resources["ComparisonFeature1Description"], "");

				if (Page.RouteData.Values["fileformat"] != null)
				{
					if (!Page.RouteData.Values["fileformat"].ToString().ToLower().Equals("total"))
					{
						metatitle = "Free Online Compare " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " Documents";
						metadescription = "Compare your " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents in seconds. 100% free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document comparison, compare " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " files, secure and easy to use! GroupDocs.App — advanced online tool that solving any problems with any files.";
						metakeywords = "Compare " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents, " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " comparison tool, " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " comparison, free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document comparison, ilove " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document, " + Page.RouteData.Values["fileformat"].ToString().ToUpper();
						hheading.InnerHtml = metatitle;
						hdescription.InnerHtml = "Online diff tool that allows to compare two " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents from any device, with a modern browser like Chrome, Opera and Firefox.";
						fileFormat = Page.RouteData.Values["fileformat"].ToString().ToUpper() + " ";                        
					}
				}
			}

			Page.Title = metatitle;
			Page.MetaDescription = metadescription;
		}

		private string GetValidFileExtensions(string validationExpression)
		{
			string validFileExtensions = validationExpression.Replace(".", "").Replace("|", ", ").ToUpper();

			int index = validFileExtensions.LastIndexOf(",");
			if (index != -1)
			{
				string substr = validFileExtensions.Substring(index);
				string str = substr.Replace(",", " or");
				validFileExtensions = validFileExtensions.Replace(substr, str);
			}

			return validFileExtensions;
		}

		private string TitleCase(string value)
		{
			return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
		}

		protected void btnCompare_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
                Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";

                // Access the File using the Name of HTML INPUT File.
                HttpPostedFile postedFile = Request.Files["ctl00$MainContent$FileUpload1"];
				HttpPostedFile postedFile2 = Request.Files["ctl00$MainContent$FileUpload2"];

				pMessage.Attributes.Remove("class");
				pMessage.InnerHtml = "";

				// Check if File is available.                

				if ((postedFile != null && postedFile.ContentLength > 0) && (postedFile2 != null && postedFile2.ContentLength > 0))
				{
					// remove any invalid character from the filename.
					string fn = Regex.Replace(System.IO.Path.GetFileName(postedFile.FileName).Trim(), @"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|[\s\.])[^\\\/:*"" ?<>|]{ 1,254}\z", "");
					fn = fn.Replace(" ", String.Empty);

					string fn2 = Regex.Replace(System.IO.Path.GetFileName(postedFile2.FileName).Trim(), @"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|[\s\.])[^\\\/:*"" ?<>|]{ 1,254}\z", "");
					fn2 = fn2.Replace(" ", String.Empty);

					if (!System.IO.Path.GetExtension(fn).ToLower().Equals(System.IO.Path.GetExtension(fn2).ToLower()))
					{
						pMessage.InnerHtml = "Please select the same file types for Source & Target documents.";
						pMessage.Attributes.Add("class", "alert alert-danger");
						return;
					}


					foreach (char c in System.IO.Path.GetInvalidFileNameChars())
					{
						fn = fn.Replace(c, '_');
					}

					fn = fn.Replace(" ", "_").Replace("#", "").Replace("'", "");

					string SaveLocation = Configuration.AssetPath + fn.Replace(" ", "_").Replace("#", "");
					SaveLocation = SaveLocation.Replace("'", "");

					foreach (char c in System.IO.Path.GetInvalidFileNameChars())
					{
						fn2 = fn2.Replace(c, '_');
					}

					fn2 = fn2.Replace(" ", "_").Replace("#", "").Replace("'", "");

					string SaveLocation2 = Configuration.AssetPath + fn2.Replace(" ", "_").Replace("#", "");
					SaveLocation2 = SaveLocation2.Replace("'", "");

					try
					{
						postedFile.SaveAs(SaveLocation);
						postedFile2.SaveAs(SaveLocation2);

						var isFileUploaded = FileManager.UploadFile(SaveLocation, "emailTo.Value");
						if ((isFileUploaded != null) && (isFileUploaded.FileName.Trim() != ""))
						{
							var isFileUploaded2 = FileManager.UploadFileToFolder(SaveLocation2, "emailTo.Value", isFileUploaded.FolderId.Trim());
							if ((isFileUploaded2 != null) && (isFileUploaded2.FileName.Trim() != ""))
							{
								Response.Redirect("/comparison/" + isFileUploaded.FolderId + "/" + HttpUtility.UrlEncode(isFileUploaded.FileName.Trim()) + "/" + HttpUtility.UrlEncode(isFileUploaded2.FileName.Trim()) + "/");
							}
							else
							{
								pMessage.InnerHtml = "Unable to upload target file, please try again.";
								pMessage.Attributes.Add("class", "alert alert-danger");
							}
						}
						else
						{
							pMessage.InnerHtml = "Unable to upload source file, please try again.";
							pMessage.Attributes.Add("class", "alert alert-danger");
						}
					}
					catch (Exception ex)
					{
						pMessage.InnerHtml = "Error: " + ex.Message;
						pMessage.Attributes.Add("class", "alert alert-danger");
					}
				}
			}
		}
	}
}