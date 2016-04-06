using System.Runtime.Serialization;
using GroupDocs.Comparison.Common.Changes;

namespace GroupDocsComparisonMvcDemo.Response
{
    [DataContract(Name = "updateChangeRequest")]
    public class UpdateChangeRequest
    {
        [DataMember(Name = "resultFileId")]
        public string ResultFileId { get; set; }
        [DataMember(Name = "changes")]
        public ChangeInfo[] Changes { get; set; }
    }
}
