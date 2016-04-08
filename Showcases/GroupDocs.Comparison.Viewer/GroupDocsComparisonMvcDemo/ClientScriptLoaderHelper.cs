using System;
using System.Text;
using System.Web;
using System.Web.Optimization;

namespace GroupDocsComparisonMvcDemo
{
    /// <summary>
    /// Client Script Loader Helper
    /// </summary>
    public class ClientScriptLoaderHelper : IHtmlString
    {
        private ClientHelper helper;
        private readonly ApplicationPathFinder _applicationPathFinder;
        private readonly ComparisonWidgetSettings _settings;

        internal ClientScriptLoaderHelper(ComparisonWidgetSettings settings, ClientHelper helper)
        {
            _applicationPathFinder = new ApplicationPathFinder();
            _settings = settings;
            //Set ClientHelper
            this.helper = helper;
        }
        
        public override string ToString()
        {
            var applicationPath = _applicationPathFinder.GetApplicationPath();

            var result = new StringBuilder();

            var embeddeScriptsTemplate = String.Format("<script type='text/javascript' src='{0}{1}/{{0}}'></script>", applicationPath, _settings.EmbeddedResourceUrl);

            result.AppendFormat(embeddeScriptsTemplate, "scripts/lib/jquery-1.9.1.min.js");
            result.AppendFormat(embeddeScriptsTemplate, "scripts/lib/jquery-ui-1.10.3.min.js");
            result.AppendFormat(embeddeScriptsTemplate, "scripts/lib/knockout-3.2.0.js");

            result.AppendFormat(embeddeScriptsTemplate, "scripts/lib/turn.min.js");
            result.AppendFormat(embeddeScriptsTemplate, "scripts/lib/modernizr.2.6.2.Transform2d.min.js");
            result.AppendFormat(embeddeScriptsTemplate, "scripts/lib/installableViewer.js");

            result.AppendLine("<script type='text/javascript'> $.ui.groupdocsViewer.prototype.applicationPath = 'http://localhost:13390/';</script>");
            result.AppendLine("<script type='text/javascript'> $.ui.groupdocsViewer.prototype.useHttpHandlers = false;</script>");
            result.AppendFormat(embeddeScriptsTemplate, "scripts/lib/GroupdocsViewer.all.js");

            result.AppendFormat(Scripts.Render(BundleTable.Bundles.ResolveBundleUrl(BundleConfigurator.AddPrefix("~/comparison/libs", false))).ToString());

            result.AppendLine("<script type='text/javascript'>");
            result.AppendFormat("var gdComparisonPrefix ='{0}';\n", _settings.AppPrefix);

            result.AppendLine("ViewContext = {};");
            result.AppendLine("ViewContext.Credentials = {");
            result.AppendLine("    userId: '',");
            result.AppendLine("    privateKey: '',");
            result.AppendLine("    primaryEmail: '',");
            result.AppendLine("    serviceAddress: '',");
            result.AppendLine("    userName: 'Anonymous'");
            result.AppendLine("    };");

            result.AppendFormat("ViewContext.AppPath = '{0}';\n", _settings.AppPrefix);
            result.AppendFormat("ViewContext.PortalServiceHost = '{0}';\n", _settings.ServiceUrl);

            result.AppendLine("Container = new JsInject.Container();");
            result.AppendLine("Container.Register('Cacher', function (c) { return $.jCacher; }, true);");
            result.AppendLine("Container.Register('Rx.Observable', function (c) { return Rx.Observable; }, true);");
            result.AppendLine("Container.Register('RequestObservable', function (c) { return $.ajaxAsObservable; }, true);");
            result.AppendLine("Container.Register('AsyncSubject', function (c) { return new Rx.AsyncSubject(); }, false);");
            result.AppendLine("Container.Register('PortalService', function (c) { return new jSaaspose.PortalService(ViewContext.PortalServiceHost); }, true);");
            result.AppendLine("Container.Register('PathProvider', function (c) { return jSaaspose.utils; }, true);");
            result.AppendLine("Container.Register('HttpProvider', function (c) { return jSaaspose.http; }, true);");

            result.AppendLine("function jerror(msg) {");
            result.AppendLine("    if (!msg) msg = \"Sorry, we're unable to perform your request right now. Please try again later.\";");
            result.AppendLine("    $(\"#jerrorMsg\").text(msg);");
            result.AppendLine("    $('#jerror').modal('show');");
            result.AppendLine("}");
            result.AppendLine("");
            result.AppendLine("$(document).ready(function () {");
            result.AppendLine("    $('#jerror').modal({ show: false });");
            result.AppendLine("});");
            result.AppendLine("var isPublic = true;");
            result.AppendLine("var showErrorDialog = '';");
            result.AppendLine("var documentId = '';");
            result.AppendLine("</script>");

            result.AppendFormat(embeddeScriptsTemplate, "scripts/lib/require.js");

            result.AppendLine("<script type='text/javascript'>");
            const string settings = @"
                define('comparison-settings', function () {{ 
                    var sessionId = '',
                        sourceFileId = '',
                        targetFileId = '',
                        resultFileId = '{0}',
                        thumbsImageBase64Encoded = '{2}',
                        mode = 'embed';

                    return {{
                        sessionId: sessionId,
                        sourceFileId: sourceFileId,
                        targetFileId: targetFileId,
                        resultFileId: resultFileId,
                        thumbsImageBase64Encoded: thumbsImageBase64Encoded,
                        mode: mode
                    }};
                }});";

            result.AppendLine(String.Format(settings, "", "", ""));

            result.AppendLine("</script>");

            result.AppendFormat(Scripts.Render(String.Format("~/{0}/comparison/core", _settings.AppClientFilesPrefix)).ToString());
            result.AppendFormat(embeddeScriptsTemplate, "scripts/comparison2/core/main.js");
            result.AppendFormat(embeddeScriptsTemplate, "scripts/comparison2/redline.js");
            
            result.Append(helper.GenerateClientCode());

            return result.ToString();
        }

        string IHtmlString.ToHtmlString()
        {
            return ToString();
        }
    }
}
