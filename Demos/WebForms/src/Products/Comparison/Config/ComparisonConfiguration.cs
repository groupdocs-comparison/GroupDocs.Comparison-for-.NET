using GroupDocs.Comparison.WebForms.Products.Common.Config;
using GroupDocs.Comparison.WebForms.Products.Common.Util.Parser;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace GroupDocs.Comparison.WebForms.Products.Comparison.Config
{
    /// <summary>
    /// CommonConfiguration
    /// </summary>
    public class ComparisonConfiguration : CommonConfiguration
    {
        [JsonProperty]
        private string filesDirectory = "DocumentSamples/Comparison";

        [JsonProperty]
        private string resultDirectory = "DocumentSamples/Comparison/Compared";

        [JsonProperty]
        private int preloadResultPageCount;

        /// <summary>
        /// Constructor
        /// </summary>
        public ComparisonConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("comparison");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            // get Comparison configuration section from the web.config            
            filesDirectory = valuesGetter.GetStringPropertyValue("filesDirectory", filesDirectory);
            if (!IsFullPath(filesDirectory))
            {
                filesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filesDirectory);
                if (!Directory.Exists(filesDirectory))
                {
                    Directory.CreateDirectory(filesDirectory);
                }
            }
            resultDirectory = valuesGetter.GetStringPropertyValue("resultDirectory", resultDirectory);
            if (!IsFullPath(resultDirectory))
            {
                resultDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, resultDirectory);
                if (!Directory.Exists(resultDirectory))
                {
                    Directory.CreateDirectory(resultDirectory);
                }
            }
            preloadResultPageCount = valuesGetter.GetIntegerPropertyValue("preloadResultPageCount", preloadResultPageCount);
        }

        private static bool IsFullPath(string path)
        {
            return !String.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(System.IO.Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
        }

        public void SetFilesDirectory(string filesDirectory)
        {
            this.filesDirectory = filesDirectory;
        }

        public string GetFilesDirectory()
        {
            return filesDirectory;
        }

        public void SetResultDirectory(string resultDirectory)
        {
            this.resultDirectory = resultDirectory;
        }

        public string GetResultDirectory()
        {
            return resultDirectory;
        }

        public void SetPreloadResultPageCounty(int preloadResultPageCount)
        {
            this.preloadResultPageCount = preloadResultPageCount;
        }

        public int GetPreloadResultPageCount()
        {
            return preloadResultPageCount;
        }
    }
}