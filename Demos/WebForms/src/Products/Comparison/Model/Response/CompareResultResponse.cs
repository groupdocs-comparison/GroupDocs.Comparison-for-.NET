using GroupDocs.Comparison.Result;
using GroupDocs.Comparison.WebForms.Products.Common.Entity.Web;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GroupDocs.Comparison.WebForms.Products.Comparison.Model.Response
{
    public class CompareResultResponse
    {
        /// <summary>
        /// List of changies
        /// </summary>
        [JsonProperty]
        private ChangeInfo[] changes;

        /// <summary>
        /// List of images of pages with marked changes
        /// </summary>
        [JsonProperty]
        private List<PageDescriptionEntity> pages;

        /// <summary>
        /// Unique key of results
        /// </summary>
        [JsonProperty]
        private string guid;

        /// <summary>
        /// Extension of compared files, for saving Comparison results
        /// </summary>
        [JsonProperty]
        private string extension;

        public void SetChanges(ChangeInfo[] changes)
        {
            this.changes = changes;
        }

        public ChangeInfo[] GetChanges()
        {
            return changes;
        }

        public void SetPages(List<PageDescriptionEntity> pages)
        {
            this.pages = pages;
        }

        public void AddPage(PageDescriptionEntity page)
        {
            this.pages.Add(page);
        }

        public List<PageDescriptionEntity> GetPages()
        {
            return pages;
        }

        public void SetGuid(string guid)
        {
            this.guid = guid;
        }

        public string GetGuid()
        {
            return guid;
        }

        public void SetExtension(string extension)
        {
            this.extension = extension;
        }

        public string GetExtension()
        {
            return extension;
        }
    }
}