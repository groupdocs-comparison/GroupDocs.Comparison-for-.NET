using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using GroupDocs.Comparison.Common.Changes;

namespace GroupDocsComparisonMvcDemo
{
    /// <summary>
    /// Groupdocs comparison widget client helper
    /// </summary>
    public class ClientHelper : IHtmlString
    {
        internal readonly ComparisonService _service;

        private string _targetElementSelector;
        private bool _immediateCompare;
        private readonly ComparisonWidgetSettings _settings;

        internal ClientHelper(ComparisonWidgetSettings settings, string targetElementSelector)
        {
            //Create comparison service
            _service = new ComparisonService(settings);
            //Set comparison settings
            _settings = settings;
            _targetElementSelector = targetElementSelector;
        }

        /// <summary>
        /// Set the source file for comparison
        /// </summary>
        /// <param name="filePath">Absolute path to the source file for comparison</param>
        /// <param name="stream">Optional. If provided the stream is used as a source</param>
        /// <returns></returns>
        public ClientHelper SourceFileName(string filePath, string filePassword = "")
        {
            //Set source file name
            _service.SourceFileName(filePath, filePassword);
            return this;
        }

        /// <summary>
        /// Set the target file for comparison
        /// </summary>
        /// <param name="filePath">Absolute path to the target file for comparison</param>
        /// <param name="stream">Optional. If provided the stream is used as a target</param>
        /// <returns></returns>
        public ClientHelper TargetFileName(string filePath, string filePassword = "")
        {
            //Set target file name
            _service.TargetFileName(filePath, filePassword);
            return this;
        }

        /// <summary>
        /// Set the result file name. The result of comparison will be stored in the specified file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public ClientHelper ResultFileName(string filePath)
        {
            //Set result file name
            _service.ResultFileName(filePath);
            return this;
        }

        /// <summary>
        /// Force comparison to be started as soon as the comparison widget is initialized
        /// </summary>
        /// <returns></returns>
        public ClientHelper ImmediateCompare()
        {
            //Immediate compare 
            _immediateCompare = true;
            return this;
        }

        public void UpdateChanges(ChangeInfo[] changes)
        {
            //Update changes
            _service.UpdateChanges(changes);
        }

        public ChangeInfo[] GetChanges()
        {
            //Return changes
            return _service.Changes;
        }

        private static string SerializeChanges(IEnumerable changes)
        {
            //Serealize changes
            if (changes == null) return string.Empty;
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(changes);
        }

        public override string ToString()
        {
            return string.Empty;
        }

        internal string GenerateClientCode()
        {

            var changes = String.Empty;
            if (_immediateCompare)
            {
                //Compare documents and get changes
                var changesArray = _service.Compare();
                //Serealize changes
                changes = SerializeChanges(changesArray);
            }

            var result = new StringBuilder();
            //Create script
            result.AppendFormat(@"<script type='text/javascript'>
                                    $('{0}').groupdocsComparison({{
                                        servicePrefix: '{1}',
                                        context: '{2}',
                                        resultFileName: '{3}',
                                        immediateCompare: {4},
                                        changes: {5}
                                    }});
                                </script>",
                _targetElementSelector,
                _settings.ClientFilesPrefix,
                _service.ContextName,
                _service.resultFileName,
                _immediateCompare.ToString().ToLower(),
                String.IsNullOrEmpty(changes) ? "[]" : changes
                );

            return result.ToString();
        }

        string IHtmlString.ToHtmlString()
        {
            return ToString();
        }
    }
}
