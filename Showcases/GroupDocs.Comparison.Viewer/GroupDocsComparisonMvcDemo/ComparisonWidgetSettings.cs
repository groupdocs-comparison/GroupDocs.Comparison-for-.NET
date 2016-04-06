using System;
using System.Web;
using GroupDocs.Comparison.Common.ComparisonSettings;

namespace GroupDocsComparisonMvcDemo
{
    /// <summary>
    /// Groupdocs Comparison Settings
    /// </summary>
    public class ComparisonWidgetSettings
    {
        private static string _clientFilesPrefix = "gd-comparison";
        //this is app client
        public string AppClientFilesPrefix
        {
            get
            {
                return string.Format("{0}", ClientFilesPrefix);
            }
        }

        public string AppPrefix
        {
            get
            {
                return String.Format("{0}/{1}", (HttpRuntime.AppDomainAppVirtualPath ?? string.Empty).TrimEnd('/'), AppClientFilesPrefix);
            }
        }

        /// <summary>
        /// Gets the service URL.
        /// </summary>
        /// <value>
        /// The service URL.
        /// </value>
        public string ServiceUrl
        {
            get
            {
                return String.Format("{0}/comparison2/", AppPrefix);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string EmbeddedResourceUrl
        {
            get
            {
                return String.Format("{0}/embedded", AppClientFilesPrefix);
            }
        }

        internal string EmbeddedResourceUrlRooted
        {
            get
            {
                return String.Format("{0}/embedded", AppPrefix);
            }
        }

        /// <summary>
        ///  Comparison widget settings class constructor
        /// </summary>
        public ComparisonWidgetSettings()
        {
            ComparisonBehavior = new ComparisonSettings();
            Locale = SupportedLocales.DefaultLocale;
        }


        /// <summary>
        /// Set or get the client prefix.
        /// </summary>
        /// <remarks>
        /// The default value is "gd-comparison"
        /// </remarks>
        public string ClientFilesPrefix
        {
            get { return _clientFilesPrefix; }
            set { _clientFilesPrefix = value; }
        }

        /// <summary>
        /// Base url to be used
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Path where all documents will be stored
        /// </summary>
        public string RootStoragePath{get; set; }

        /// <summary>
        /// Set path to Groupdocs license file
        /// </summary>
        public string LicensePath { get; set; }
        
        /// <summary>
        /// Comparison behavior settings
        /// </summary>
        public ComparisonSettings ComparisonBehavior { get; private set; }

        /// <summary>
        /// Get or set the locale for the widget. 
        /// </summary>
        public SupportedLocales Locale { get; set; }
    }
}
