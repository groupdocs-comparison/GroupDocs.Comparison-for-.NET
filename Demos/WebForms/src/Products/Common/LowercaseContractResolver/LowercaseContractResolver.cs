using Newtonsoft.Json.Serialization;

namespace GroupDocs.Comparison.WebForms.Products.Common.Util.LowercaseContractResolver
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return char.ToLower(propertyName[0]) + propertyName.Substring(1);
        }
    }
}