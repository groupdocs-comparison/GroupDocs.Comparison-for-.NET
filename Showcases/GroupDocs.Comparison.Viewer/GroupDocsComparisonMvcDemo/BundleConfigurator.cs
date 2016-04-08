using System;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Optimization;

namespace GroupDocsComparisonMvcDemo
{
    /// <summary>
    /// 
    /// </summary>
    public static class BundleConfigurator
    {
        private static GroupDocsComparisonMvcDemo.ComparisonWidgetSettings Settings;

        /// <summary>
        /// Adds the prefix.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="respectBundleOptimization">if set to <c>true</c> [respect bundle optimization].</param>
        /// <returns></returns>
        public static string AddPrefix(string file, bool respectBundleOptimization = true)
        {
            var prefix = String.Format("~/{0}/", (!respectBundleOptimization || BundleTable.EnableOptimizations) ? Settings.AppClientFilesPrefix : Settings.EmbeddedResourceUrl);
            return file.Replace("~/", prefix);
        }

        /// <summary>
        /// Configures the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public static void Configure(GroupDocsComparisonMvcDemo.ComparisonWidgetSettings settings)
        {
            Settings = settings;

            BundleTable.VirtualPathProvider = new EmbeddedVirtualPathProvider(HostingEnvironment.VirtualPathProvider,
                settings);
            BundleTable.EnableOptimizations = false;

            var bundles = BundleTable.Bundles;

            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore(".intellisense.js", OptimizationMode.Always);
            bundles.IgnoreList.Ignore("-vsdoc.js", OptimizationMode.Always);
            bundles.IgnoreList.Ignore(".debug.js", OptimizationMode.Always);
            bundles.IgnoreList.Ignore("main.js", OptimizationMode.Always);

            var libsBundle = new ScriptBundle(AddPrefix("~/comparison/libs", false))
                .Include(
                    AddPrefix("~/Scripts/Lib/bootstrap.min.js"),
                    AddPrefix("~/Scripts/Lib/amplify.js"),
                    AddPrefix("~/Scripts/Lib/underscore.js"),
                    AddPrefix("~/Scripts/Lib/require.js"),

                    AddPrefix("~/Scripts/Lib/groupdocs.custombindings.js"),
                    AddPrefix("~/Scripts/Lib/jquery.scrollTo-1.4.2-min.js"),
                    AddPrefix("~/Scripts/Lib/koExternalTemplateEngine_all.js"),

                    AddPrefix("~/Scripts/Lib/jGroupdocs.InstallableViewerPortalService.js"),
                    AddPrefix("~/Scripts/Lib/installableComparison.js"),
                    AddPrefix("~/Scripts/Lib/jquery.confirm.js")/*,

                    AddPrefix("~/Scripts/Lib/installableViewer.js"),
                    AddPrefix("~/Scripts/Lib/jquery-1.9.1.min.js"),
                    AddPrefix("~/Scripts/Lib/jquery-ui-1.10.3.min.js"),
                    AddPrefix("~/Scripts/Lib/knockout-3.2.0.js"),
                    AddPrefix("~/Scripts/Lib/turn.min.js"),
                    AddPrefix("~/Scripts/Lib/modernizr.2.6.2.Transform2d.min.js"),
                    AddPrefix("~/Scripts/Lib/GroupdocsViewer.all.js")*/
                );
            bundles.Add(libsBundle);

            var comparisonBundle = new ScriptBundle(AddPrefix("~/comparison/core", false))
                .Include(
                    AddPrefix("~/Scripts/Comparison2/core/model/model.changeinfo.js"),
                    AddPrefix("~/Scripts/Comparison2/core/model/model.changes.js"),
                    AddPrefix("~/Scripts/Comparison2/core/model/model.compare.js"),
                    AddPrefix("~/Scripts/Comparison2/core/model/model.documentdetails.js"),

                    AddPrefix("~/Scripts/Comparison2/core/repository/baserepository.js"),
                    AddPrefix("~/Scripts/Comparison2/core/repository/repository.compare.js"),
                    AddPrefix("~/Scripts/Comparison2/core/dataservice/dataservice.compare.js"),

                    AddPrefix("~/Scripts/Comparison2/core/vm/vm.diffnavigator.js"),
                    AddPrefix("~/Scripts/Comparison2/core/vm/vm.embed.js"),
                    AddPrefix("~/Scripts/Comparison2/core/vm/vm.progress.js"),
                    AddPrefix("~/Scripts/Comparison2/core/vm/vm.selector.js"),
                    AddPrefix("~/Scripts/Comparison2/core/vm/vm.viewer.js"),

                    AddPrefix("~/Scripts/Comparison2/core/binder.js"),
                    AddPrefix("~/Scripts/Comparison2/core/config.js"),
                    AddPrefix("~/Scripts/Comparison2/core/model.js"),
                    AddPrefix("~/Scripts/Comparison2/core/repository.js"),
                    AddPrefix("~/Scripts/Comparison2/core/utils.js"),
                    AddPrefix("~/Scripts/Comparison2/core/vm.js")
                );

            bundles.Add(comparisonBundle);

            var stylesBundle = new Bundle(AddPrefix("~/comparison/styles", false),
                new CustomCssBundleTransform(settings))
                .Include(AddPrefix("~/Css/bootstrap.css"),
                    AddPrefix("~/Css/jquery-ui-1.8.16.custom.css"),
                    AddPrefix("~/Css/DocumentViewer.css"),
                    AddPrefix("~/Css/Comparison.css"));
            bundles.Add(stylesBundle);
        }

        public class CustomCssBundleTransform : IBundleTransform
        {
            private readonly string _contentType;
            private readonly GroupDocsComparisonMvcDemo.ComparisonWidgetSettings _settings;

            public CustomCssBundleTransform(GroupDocsComparisonMvcDemo.ComparisonWidgetSettings settings, string contentType = "text/css")
            {
                _contentType = contentType;
                _settings = settings;
            }

            public void Process(BundleContext context, BundleResponse bundle)
            {
                if (bundle == null)
                {
                    throw new ArgumentNullException("bundle");
                }
                context.HttpContext.Response.Cache.SetLastModifiedFromFileDependencies();
                var prefix = String.Format("{0}/", _settings.EmbeddedResourceUrlRooted);
                bundle.Content = Regex.Replace(bundle.Content, "../images/sprites.png", prefix + "images/sprites.png", RegexOptions.IgnoreCase);
                bundle.Content = Regex.Replace(bundle.Content, "../images/spinner.gif", prefix + "images/spinner.gif", RegexOptions.IgnoreCase);
                bundle.Content = Regex.Replace(bundle.Content, "../images/mainbg.png", prefix + "images/mainbg.png", RegexOptions.IgnoreCase);
                bundle.Content = Regex.Replace(bundle.Content, "../images/colorpicker_", prefix + "images/colorpicker/colorpicker_", RegexOptions.IgnoreCase);
                bundle.Content = Regex.Replace(bundle.Content, "../images/bg-trial.png", prefix + "images/bg-trial.png", RegexOptions.IgnoreCase);

                bundle.ContentType = _contentType;
            }
        }
    }
}