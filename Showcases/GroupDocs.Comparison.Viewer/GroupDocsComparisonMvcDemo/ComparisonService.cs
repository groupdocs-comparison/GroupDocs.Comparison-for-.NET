using System;
using System.IO;
using System.Linq;
using GroupDocs.Comparison.Common.Changes;
using GroupDocs.Viewer;
using GroupDocs.Comparison.Common.ComparisonSettings;

namespace GroupDocsComparisonMvcDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class ComparisonService
    {
        private string name;
        private ComparingDocument _source;
        private ComparingDocument _target;
        internal string resultFileName;
        private readonly string _contextName;
        private readonly ComparisonWidgetSettings _settings;
        private GroupDocs.Comparison.Comparer comparison;
        private static GroupDocs.Comparison.Common.ICompareResult results;

        internal string ContextName
        {
            get
            {
                //Return context name
                return _contextName;
            }
        }

        /// <summary>
        /// Instantiate a comparison service
        /// </summary>
        public ComparisonService(ComparisonWidgetSettings settings)
        {
            //Set new context name
            _contextName = Guid.NewGuid().ToString();
            //Set settings
            _settings = settings;

            //Set Viewer license
            if (!String.IsNullOrEmpty(settings.LicensePath))
            {
                License lic = new License();
                lic.SetLicense(settings.LicensePath);
            }
        }

        /// <summary>
        /// Set the source file for comparison
        /// </summary>
        /// <param name="filePath">Absolute path to the source file for comparison</param>
        public void SourceFileName(string filePath, string documentPassword = "")
        {
            //Combine source file path
            var sourceFile = filePath.Replace("\\", "\\\\");
            sourceFile = Path.Combine(_settings.RootStoragePath, sourceFile);
            //Open source document
            _source = new ComparingDocument(sourceFile, documentPassword);
        }

        /// <summary>
        /// Set the target file for comparison
        /// </summary>
        /// <param name="filePath">Absolute path to the target file for comparison</param>
        public void TargetFileName(string filePath, string documentPassword = "")
        {
            //Combine target file path
            var targetFile = filePath.Replace("\\", "\\\\");
            targetFile = Path.Combine(_settings.RootStoragePath, targetFile);
            //Open target document
            _target = new ComparingDocument(targetFile, documentPassword);
        }


        /// <summary>
        /// Set the result file name. The result of comparison will be stored in the specified file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public void ResultFileName(string filePath)
        {
            //Combine result file path
            resultFileName = filePath.Replace("\\", "\\\\");
            int lastDotIndex = resultFileName.LastIndexOf(".");
            if (lastDotIndex != -1)
            {
                name = resultFileName.Substring(0, lastDotIndex + 1);
                resultFileName = name + _target.Extention;
            }
            else
            {
                name = resultFileName;
                resultFileName = resultFileName + "." + _target.Extention.ToString().ToLower();
            }
        }

        /// <summary>
        /// Start the comparison
        /// </summary>
        /// <returns></returns>
        public ChangeInfo[] Compare()
        {
            //Create new comparison
            comparison = new GroupDocs.Comparison.Comparer();
            var resultName = Path.Combine(_settings.RootStoragePath, resultFileName);
            //Compare documents
            results = comparison.Compare(_source.Content, _source.DocumentPassword, _target.Content, _target.DocumentPassword, new GroupDocs.Comparison.Common.ComparisonSettings.ComparisonSettings { DeletedItemsStyle = new StyleSettings { StrikeThrough = true }, GenerateSummaryPage = true, CalculateComponentCoordinates = true });

            //Get changes
            var changes = results.GetChanges();

            results.SaveDocument(resultName);

            //Cut changes and return
            return changes.ToArray();
        }

        /// <summary>
        /// Updates changes
        /// </summary>
        /// <param name="changesToUpdate"></param>
        public void UpdateChanges(ChangeInfo[] changesToUpdate)
        {
            //Combine result file name
            resultFileName = Guid.NewGuid() + name;
            var resultFile = Path.Combine(_settings.RootStoragePath, resultFileName);
            //Updete changes
            results.UpdateChanges(changesToUpdate);
        }

        public ChangeInfo[] Changes
        {
            get
            {
                //Return changes
                return results.GetChanges();
            }
        }
    }
}