using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using GroupDocs.Comparison.Common.Changes;
using GroupDocsComparisonMvcDemo.Response;

namespace GroupDocsComparisonMvcDemo.Controllers
{
    public class ComparisonController : Controller
    {
        public ActionResult GetResource(string path)
        {
            //Set namespace
            var nameSpace = "GroupDocsComparisonMvcDemo";
            var manifestResourceName = string.Format("{0}.{1}", nameSpace, path.Replace('/', '.'));
            var actualResourceName = typeof(BundleConfigurator).Assembly.GetManifestResourceNames()
                .FirstOrDefault(s => s.Equals(manifestResourceName, StringComparison.InvariantCultureIgnoreCase));
            var stream = typeof(BundleConfigurator).Assembly.GetManifestResourceStream(actualResourceName);

            //Set file extention
            var fileExtension = String.Empty;
            var index = path.LastIndexOf('.');
            if (index != -1) fileExtension = path.Substring(index + 1);

            //Check stream
            if (stream == null) ThrowResourceNotFoundException(path);

            Stream imageStream;

            //Sort files by extention and return them
            switch (fileExtension)
            {
                case "gif":
                    imageStream = new MemoryStream();
                    stream.Position = 0;
                    stream.CopyTo(imageStream);
                    imageStream.Position = 0;
                    return new FileStreamResult(imageStream, "image/gif");
                case "png":
                    imageStream = new MemoryStream();
                    stream.Position = 0;
                    stream.CopyTo(imageStream);
                    imageStream.Position = 0;
                    return new FileStreamResult(imageStream, "image/png");
                case "jpg":
                case "jpeg":
                    imageStream = new MemoryStream();
                    stream.Position = 0;
                    stream.CopyTo(imageStream);
                    imageStream.Position = 0;
                    return new FileStreamResult(imageStream, "image/jpeg");
            }

            string script = "";

            using (var streamReader = new StreamReader(stream))
            {
                script = streamReader.ReadToEnd();
            }

            switch (fileExtension)
            {
                case "js":
                    return new JavaScriptResult { Script = script };
                case "html":
                case "htm":
                    return new ContentResult { Content = script, ContentType = "text/html" };
                case "css":
                    return new ContentResult { Content = script, ContentType = "text/css" };
                default:
                    throw new NotSupportedException("File type is not supported");
            }
        }

        public ActionResult ApplyChanges(ChangeInfo[] changes)
        {
            //Update changes
            ComparisonWidget.UpdateChanges(changes);

            //Create update changes response
            UpdateChangesResponse response = new UpdateChangesResponse();

            //Serialize response
            var serializer = new JavaScriptSerializer();
            var serializedData = serializer.Serialize(response);
            return Content(serializedData);
        }

        public ActionResult GetChanges()
        {
            //Create get changes response
            GetChangesResponse response = new GetChangesResponse();
            response.Result.Changes = ComparisonWidget.GetChanges();
            response.Result.ResultFileName = ComparisonWidget.helper._service.resultFileName;

            //Serialize response
            var serializer = new JavaScriptSerializer();
            var serializedData = serializer.Serialize(response);
            return Content(serializedData);
        }

        private static void ThrowResourceNotFoundException(string resource)
        {
            //Throw new exception
            throw new Exception("Resource " + resource + " not found!");
        }
    }
}