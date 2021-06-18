
using Newtonsoft.Json;

namespace GroupDocs.Comparison.WebForms.Products.Comparison.Model.Request
{
    public class CompareFileDataRequest
    {
        [JsonProperty]
        private string guid { get; set; }

        [JsonProperty]
        private string password { get; set; }

        public void SetGuid(string guid)
        {
            this.guid = guid;
        }

        public string GetGuid()
        {
            return guid;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public string GetPassword()
        {
            return password;
        }
    }
}