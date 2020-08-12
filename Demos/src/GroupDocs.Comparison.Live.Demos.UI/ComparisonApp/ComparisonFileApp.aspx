<%@ Page Title="DOC, DOCX, DOT, DOTX, DOCM, DOTM, RTF, XLS, XLSX, XLSM, XLSB, CSV, XLS2003, PPT, PPTX, PPS, PPSX, EML, EMLX, MSG, MHTML, ONE, VSDX, ODT, OTT, ODS, ODP, OTP, PDF, DXF, DWG, JPEG, BMP, PNG, GIF, DCM, DICOM, HTM, HTML, TXT, DJVU and files online Comparison - GroupDocs.App" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComparisonFileApp.aspx.cs" Inherits="GroupDocs.Comparison.Live.Demos.UI.ComparisonApp.ComparisonFileApp" %>

<asp:Content ID="HeadContents1" ContentPlaceHolderID="HeadContents" runat="server">

	<meta charset="UTF-8">
	<meta name="author" content="groupdocs.app" />
	<meta name="keywords" content="<%=metakeywords %>" />
	<link rel="canonical" href="https://products.groupdocs.app/comparison/total" />
	<link rel="icon" type="image/png" sizes="16x16" href="https://products.groupdocs.app/images/groupdocs1616.png">
	<meta property="og:site_name" content="Free Online <%=fileFormat  %>Document Comparison" />
	<meta property="og:title" content="<%=metatitle %>" />
	<meta property="og:description" content="<%=metadescription %>" />
	<meta property="og:image" content="https://products.groupdocs.app/images/groupdocsapp.png" />
	<meta property="og:type" content="website" />
	<meta property="og:url" content="https://products.groupdocs.app/comparison/total" />
	<meta name="twitter:card" content="summary_large_image">
	<meta name="twitter:site" content="@groupdocsapp">
	<meta name="twitter:creator" content="@groupdocsapp">
	<meta name="twitter:title" content="<%=metatitle %>">
	<meta name="twitter:description" content="<%=metadescription %>">
	<meta name="twitter:image:src" content="https://products.groupdocs.app/images/groupdocsapp.png" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<script lang="javascript" type="text/javascript">
		function TriggerFileUpload() {
			$('#<%=btnCompare.ClientID %>').click();
		}

		var size = 2;

		var id = 0;
		var id2 = 0;

		function ProgressBars() {
			if (ProgressBar() && ProgressBar2())
				return true;
			else
				return false;
		}

		function ProgressBar() {

			if (document.getElementById('<%=FileUpload1.ClientID %>').value != "") {

				document.getElementById("progressbar").style.display = "block";


				id = setInterval("progress('progressbar')", 10);

				return true;
			}
		}

		function ProgressBar2() {

			if (document.getElementById('<%=FileUpload2.ClientID %>').value != "") {

				document.getElementById("progressbar2").style.display = "block";


				id2 = setInterval("progress('progressbar2')", 10);

				return true;
			}
		}
		function progress(elementid) {
			console.log('elementid: ' + elementid);
			size = size + 1;

			if (size > 299) {
				if (elementid === 'progressbar')
					clearTimeout(id);
				else
					clearTimeout(id2);
			}

			document.getElementById(elementid).style.width = size + "%";
		}
	</script>

	<!-- GroupDocs.Apps UI Template Starts Here -->
	<asp:Panel ID="pnlTest" runat="server">
		<div class="container-fluid GroupDocsApps pb5">
			<div class="container">
				<div class="row">

					<div class="col-md-12 pt-5 pb-5" style="padding-bottom: 0px!important;">
						<asp:HiddenField ID="hdnGroupDocsProductName" runat="server" />
						<h1 id="hheading" runat="server">Free Online Document Comparison</h1>
						<h2 style="font-size: 22px !important; color: #fff !important;" id="hdescription" runat="server">Compare your Word, PDF, PowerPoint, Excel and more than 50 types of documents, 100% free online!</h2>
						<h1 runat="server" visible="false" id="hFeatureTitle"></h1>
						<h4 runat="server" visible="false" id="hPageTitle"></h4>
						<div class="uploadfile">
							<div class="col-md-12">
								<div class="col-md-6">
									<div class="filedropdown">
										<div class="filedrop" style="width: 100%!important;">
											<label class="dz-message needsclick">
												<strong>Source Document</strong><br />
												<% = Resources["DropOrUploadFile"] %></label>
											<input type="file" class="uploadfileinput" name="FileUpload1" id="FileUpload1" runat="server" />
											<br />
											<asp:RequiredFieldValidator ID="rfvFile" SetFocusOnError="true" ValidationGroup="uploadFile" runat="server"
												ErrorMessage="*" ControlToValidate="FileUpload1" Display="Dynamic"
												ForeColor="Red"></asp:RequiredFieldValidator>

											<asp:RegularExpressionValidator ValidationGroup="uploadFile" ID="ValidateFileType"
												ControlToValidate="FileUpload1" runat="server" ForeColor="Red"
												Display="Dynamic" Enabled="true" />

											<div id="file1error" style="color: red; display: block;"></div>
											<asp:HiddenField ID="hdnAllowedFileTypes" runat="server" Value="" />

											<asp:HiddenField ID="hdnDownloadFileName" runat="server" Value="" />
											<asp:HiddenField ID="hdnDownloadFileURL" runat="server" Value="" />

											<div class="fileupload">
												<div class="progress">
													<div class="progress-bar progress-bar-striped progress-bar-success progress-bar-animated" id="progressbar" role="progressbar" style="width: 0%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
												<span class="filename" id="filename1"><a onclick='removefile()'>
													<label for="uploadfileinput" class="custom-file-upload"></label>
													<i class="fa fa-times"></i></a></span>
											</div>
										</div>
									</div>
								</div>
								<div class="col-md-6">
									<div class="filedropdown">
										<div class="filedrop" style="width: 100%!important;">
											<label class="dz-message needsclick">
												<strong>Target Document</strong><br />
												<% = Resources["DropOrUploadFile"] %></label>
											<input type="file" class="uploadfileinput2" name="FileUpload2" id="FileUpload2" runat="server" />
											<br />

											<asp:RequiredFieldValidator ID="rfvFile2" SetFocusOnError="true" ValidationGroup="uploadFile" runat="server"
												ErrorMessage="*" ControlToValidate="FileUpload2" Display="Dynamic"
												ForeColor="Red"></asp:RequiredFieldValidator>

											<asp:RegularExpressionValidator ValidationGroup="uploadFile" ID="ValidateFileType2"
												ControlToValidate="FileUpload2" runat="server" ForeColor="Red"
												Display="Dynamic" Enabled="true" />
											<div id="file2error" style="color: red; display: block;"></div>
											<div class="fileupload2">
												<div class="progress">
													<div class="progress-bar progress-bar-striped progress-bar-success progress-bar-animated" id="progressbar2" role="progressbar" style="width: 0%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
												<span class="filename" id="filename2"><a onclick='removefile2()'>
													<label for="uploadfileinput2" class="custom-file-upload"></label>
													<i class="fa fa-times"></i></a></span>
											</div>
										</div>
									</div>
								</div>
								<p runat="server" id="pMessage" style="width: 65%; position: relative; color: red; margin: 50px auto 30px;">
								</p>
							</div>
							<div class="convertbtn" style="display: block;">
								<asp:Button class="btn btn-success btn-lg" ID="btnCompare" ValidationGroup="uploadFile" runat="server" OnClientClick="return ProgressBars()" OnClick="btnCompare_Click" />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>

	<div class="col-md-12 pt-5 bg-gray tc" style="padding-bottom: 0px!important;" id="dvAllFormats" runat="server">
		<div class="container">
			<div class="col-md-12 pull-left">
				<h2 class="h2title">GroupDocs.Comparison App</h2>
				<p>GroupDocs.Comparison App Supported Document Formats</p>
				<div class="diagram1 d2 d1-net">
					<div class="d1-row">
						<div class="d1-col d1-left">
							<header>Microsoft Office Formats</header>
							<ul>
								<li><strong>Word:</strong> DOC, DOCX, DOT, DOTX, DOCM, DOTM, RTF</li>
								<li><strong>Excel:</strong> XLS, XLSX, XLSM, XLSB, CSV, XLS2003</li>
								<li><strong>PowerPoint:</strong> PPT, PPTX, PPS, PPSX</li>
								<li><strong>Outlook:</strong> EML, EMLX, MSG, MHTML</li>
								<li><strong>OneNote:</strong> ONE</li>
								<li><strong>Visio:</strong> VSDX</li>
							</ul>
						</div>
						<div class="d1-col d1-right">
							<header>Other Formats</header>
							<ul>
								<li><strong>OpenDocument:</strong> ODT, OTT, ODS, ODP, OTP</li>
								<li><strong>Portable:</strong> PDF</li>
								<li><strong>AutoCAD:</strong> DXF, DWG</li>
								<li><strong>Images:</strong> JPEG, BMP, PNG, GIF, DCM, DICOM</li>
								<li><strong>Web:</strong> HTM, HTML</li>
								<li><strong>Text:</strong> TXT, Other Text Formats</li>
								<li><strong>Other:</strong> DjVu</li>
							</ul>
						</div>
					</div>
					<div class="d1-logo">
						<img src="https://www.groupdocs.cloud/templates/groupdocs/images/product-logos/90x90-noborder/groupdocs-comparison-net.png" alt=".NET files comparison API"><header>GroupDocs.Comparison</header>
						<footer><small>App</small></footer>
					</div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-12 pull-left d-flex d-wrap bg-gray appfeaturesectionlist" id="dvFormatSection" runat="server" visible="false">
		<div class="col-md-6 cardbox tc col-md-offset-3 b6">
			<h3 runat="server" id="hExtension1"></h3>
			<p runat="server" id="hExtension1Description"></p>
		</div>
	</div>

	<!-- HowTo Section -->
	<div class="col-md-12 tl bg-darkgray howtolist">
		<div class="container tl dflex">

			<div class="col-md-2 howtosectiongfx">
				<img src="/img/howto.png">
			</div>
			<div class="howtosection col-md-12">
				<div>
					<h4><i class="fa fa-question-circle "></i>&nbsp;<b>How to compare, view & download changes of a <%=fileFormat  %>document using GroupDocs Comparison App</b></h4>
					<ul>
						<li>Click inside the file drop area of source & target files to upload <%=fileFormat  %>files or drag & drop <%=fileFormat  %>files.</li>
						<li>Click "Compare Now" button to compare/view/download changes instantly.</li>
						<li>View document pages.</li>
						<li>View list of changes in a panel.</li>
						<li>View and navigate between pages.</li>
						<li>View pages thumbnails.</li>
						<li>Set page view zoom-in or zoom-out.</li>
						<li>Download the <%=fileFormat  %>output file with changes.</li>
						<li>Download the <%=fileFormat  %>output file in images format.</li>
						<li>Download the source & target <%=fileFormat  %>files without changes.</li>
					</ul>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-12 pt-5 app-features-section" style="padding-bottom: 0px!important;">
		<div class="container tc pt-5">
			<div class="col-md-4">
				<div class="imgcircle fasteasy">
					<img src="../../img/fast-easy.png" />
				</div>
				<h4>Fast and Easy <%=fileFormat  %>Comparison</h4>
				<p>Upload your <%=fileFormat  %>document and you will be redirected to the <%=fileFormat  %>Comparison Viewer app with great user experience and many more features.</p>
				<p id="h4para" runat="server" visible="false">.</p>
			</div>

			<div class="col-md-4">
				<div class="imgcircle anywhere">
					<img src="../../img/anywhere.png" />
				</div>
				<h4>Compare <%=fileFormat  %>from Anywhere</h4>
				<p>It works from all platforms including Windows, Mac, Android and iOS. All <%=fileFormat  %>files are processed on our servers. No plugin or software installation required for you..</p>
			</div>

			<div class="col-md-4">
				<div class="imgcircle quality">
					<img src="../../img/quality.png" />
				</div>
				<h4>Comparison Quality</h4>
				<p><%= Resources["PoweredBy"] %> <a runat="server" target="_blank" id="aPoweredBy"></a>All <%=fileFormat  %>files are processed using GroupDocs APIs.</p>
			</div>
		</div>
	</div>
	<script>   

		$('.fileupload').hide();
		$('.fileupload2').hide();

		$('.uploadfileinput').change(function () {
			var file = $('.uploadfileinput')[0].files[0].name;
			var ext = file.split('.').pop();
			ext = ext.toLowerCase();
			var ext1 = '';
			if ($('.uploadfileinput2')[0].files[0] != undefined) {
				ext1 = $('.uploadfileinput2')[0].files[0].name.split('.').pop().toLowerCase();
			}

			if (ext1 == '' || ext.includes(ext1)) {
				$('#filename1').text(file);
				$('.fileupload').show();
				$('#file1error').text('');
			}
			else {
				$('#file1error').text('Please select as target document (.' + ext1 + ').');
			}
		});

		$('.uploadfileinput2').change(function () {
			var file = $('.uploadfileinput2')[0].files[0].name;
			var ext = file.split('.').pop();
			ext = ext.toLowerCase();
			var ext1 = '';
			if ($('.uploadfileinput')[0].files[0] != undefined) {
				ext1 = $('.uploadfileinput')[0].files[0].name.split('.').pop().toLowerCase();
			}

			if (ext1 == '' || ext1.includes(ext)) {
				$('#filename2').text(file);
				$('.fileupload2').show();
				$('#file2error').text('');
			}
			else {
				$('#file2error').text('Please select as source document (.' + ext1 + ').');
			}
		});

		function removefile() {
			$('.fileupload').hide();
			document.getElementById('progressbar').style.width = "0%";
			$('.uploadfileinput').show();
		}

		function removefile2() {
			$('.fileupload2').hide();
			document.getElementById('progressbar2').style.width = "0%";
			$('.uploadfileinput2').show();
		}

		function AssignBtnToText(obj) {
			var t = $(obj).text();
			document.getElementById('ctl00_MainContent_OptionSelector_btnTo').innerHTML = t;
			document.getElementById("ctl00_MainContent_OptionSelector_hdnToValue").value = t;

		}

	</script>
	<script>
		if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {

			var swiper = new Swiper('.swiper-container', {
				slidesPerView: 5,
				spaceBetween: 20,
				// init: false,
				pagination: {
					el: '.swiper-pagination',
					clickable: true,
				},
				navigation: {
					nextEl: '.swiper-button-next',
					prevEl: '.swiper-button-prev',
				},
				breakpoints: {
					868: {
						slidesPerView: 4,
						spaceBetween: 20,
					},
					668: {
						slidesPerView: 2,
						spaceBetween: 0,
					}
				}
			});
		}
	</script>
</asp:Content>
