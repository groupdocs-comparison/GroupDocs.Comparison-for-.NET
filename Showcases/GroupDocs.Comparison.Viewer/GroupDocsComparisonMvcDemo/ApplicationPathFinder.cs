using System;
using System.Web;

namespace GroupDocsComparisonMvcDemo
{
    public class ApplicationPathFinder
    {
        private static string _baseUrl;

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        public string GetApplicationPath()
        {
            string applicationPath;
            string baseUrl = null;

            HttpContext context = HttpContext.Current;
            if (context == null) // WCF
            {
                applicationPath = _baseUrl;
            }
            else
            {
                HttpApplicationState application = context.Application;
                baseUrl = (string)application["GroupdocsBaseUrl"];


                if (baseUrl == null)
                {
                    HttpRequest request = context.Request;
                    applicationPath = string.Format("{0}{1}", GetApplicationHost(), request.ApplicationPath);
                }
                else
                {
                    applicationPath = baseUrl;
                }
            }

            if (!applicationPath.EndsWith("/"))
                applicationPath += "/";
            return applicationPath;
        }

        public string GetApplicationHost()
        {
            string applicationHost;
            HttpContext context = HttpContext.Current;
            if (context == null) // WCF
            {
                applicationHost = _baseUrl;
            }
            else
            {
                HttpApplicationState application = HttpContext.Current.Application;
                string baseUrl = (string)application["GroupdocsBaseUrl"];
                if (baseUrl == null)
                {
                    HttpRequest request = HttpContext.Current.Request;
                    applicationHost = String.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Host,
                                                    request.Url.Port == 80 ? String.Empty : ":" + request.Url.Port);
                }
                else
                {
                    Uri url;
                    if (Uri.TryCreate(baseUrl, UriKind.Absolute, out url))
                    {
                        applicationHost = String.Format("{0}://{1}{2}", url.Scheme, url.Host,
                                                        url.Port == 80 ? String.Empty : ":" + url.Port);
                        //applicationHost = baseUrl;
                    }
                    else
                        applicationHost = baseUrl;
                }
            }
            return applicationHost;
        }
    }
}
