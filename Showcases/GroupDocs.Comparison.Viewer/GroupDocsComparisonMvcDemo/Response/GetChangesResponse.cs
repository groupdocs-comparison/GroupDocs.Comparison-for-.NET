using System.Runtime.Serialization;
using System.Xml.Serialization;
using GroupDocs.Comparison.Common.Changes;

namespace GroupDocsComparisonMvcDemo.Response
{
    [XmlRoot(ResponseName.Changes, Namespace = "")]
    [DataContract(Name = ResponseName.Changes)]
    public class GetChangesResponse : Response<ChangesResultDownloadable>
    {
        public GetChangesResponse()
        {
            Code = ResponseCode.Ok;
        }
    }

    [DataContract]
    public class ChangesResultDownloadable : Result
    {
        [XmlElement("result_file_name")]
        [DataMember(Name = "result_file_name")]
        public string ResultFileName { get; set; }

        
        [XmlArray("changes")]
        [XmlArrayItem("change")]
        [DataMember(Name = "changes")]
        public ChangeInfo[] Changes { get; set; }
    }
}