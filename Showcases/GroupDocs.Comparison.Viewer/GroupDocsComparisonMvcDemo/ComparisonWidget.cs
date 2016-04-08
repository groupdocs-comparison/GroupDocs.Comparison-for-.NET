using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using GroupDocs.Comparison.Common.Changes;

namespace GroupDocsComparisonMvcDemo
{

    /// <summary>
    /// Handler for managing and performing custom storage of the comparison result
    /// </summary>
    /// <param name="redlineStream">The stream of the redline comparison file</param>
    /// <param name="fileName">The parameter should return a file name. Needed for correctly displaying the WEB UI</param>
    public delegate void ComparisonSaveHandler(Stream redlineStream, out string fileName);

    /// <summary>
    /// Groupdocs comparison widget
    /// </summary>
    public static class ComparisonWidget
    {
        internal static ComparisonWidgetSettings Settings;
        internal static ClientHelper helper;

        private static bool IsWebApplicationContext()
        {
            return !string.IsNullOrEmpty(HttpRuntime.AppDomainId);
        }

        /// <summary>
        /// Initialize Comparison widget
        /// </summary>
        /// <param name="widgetSettings">Comparison widgetSettings</param>
        public static void Init(ComparisonWidgetSettings widgetSettings)
        {
            //Check settings
            if (widgetSettings == null)
            {
                throw new ArgumentNullException("widgetSettings", @"GroupdocsComparison widgetSettings parameter is null");
            }

            if (!IsInitialized)
            {
                //Set settings
                Settings = widgetSettings;

                if (!IsWebApplicationContext()) return;

                //Set base url
                if (string.IsNullOrEmpty(Settings.BaseUrl))
                {
                    Settings.BaseUrl = HttpRuntime.AppDomainAppVirtualPath;
                }
            }
        }
        
        /// <summary>
        /// Returns true if the widget was already initialized.
        /// </summary>
        public static bool IsInitialized
        {
            get { return Settings != null; }
        }
        
        /// <summary>
        /// Generates scripts tags, to load required scripts for comparison widget
        /// </summary>
        /// <remarks>
        /// This method is used as helper method in MVC
        /// </remarks>
        /// <returns></returns>
        public static ClientScriptLoaderHelper CreateComparisonScriptsLoadBlock(this HtmlHelper htmlHelper)
        {
            //Create new script loader helper
            return new ClientScriptLoaderHelper(Settings, helper);
        }

        /// <summary>
        /// Generates styles tags, to load required css rules for comparison widgets
        /// </summary>
        /// <remarks>
        /// THis method is used as helper method in MVC</remarks>
        /// <returns></returns>
        public static ClientStylesLoaderHelper CreateComparisonStylesLoadBlock(this HtmlHelper htmlHelper)
        {
            //Create new styles loader helper
            return new ClientStylesLoaderHelper(Settings);
        }

        /// <summary>
        /// Generates a javascript code for initializing the Comparison Widget
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="targetElementSelector">DOM element selector</param>
        /// <returns></returns>
        public static ClientHelper Compare(this HtmlHelper htmlHelper, string targetElementSelector)
        {
            //Create new client helper
            helper = new ClientHelper(Settings, targetElementSelector);
            return helper;
        }

        public static void UpdateChanges(ChangeInfo[] changes)
        {
            //Update changes
            helper.UpdateChanges(changes);
        }

        public static ChangeInfo[] GetChanges()
        {
            //Get changes
            return helper.GetChanges();
        }
    }
}