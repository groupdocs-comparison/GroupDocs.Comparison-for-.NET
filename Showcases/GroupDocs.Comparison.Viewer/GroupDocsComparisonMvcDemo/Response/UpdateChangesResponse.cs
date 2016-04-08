using System.Runtime.Serialization;
using System.Xml.Serialization;
using GroupDocsComparisonMvcDemo.Response;

namespace GroupDocsComparisonMvcDemo.Response
{
    [XmlRoot(ResponseName.UpdateChanges, Namespace = "")]
    [DataContract(Name = ResponseName.UpdateChanges)]
    public class UpdateChangesResponse : Response<UpdateChangesResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangesResponse"/> class.
        /// </summary>
        public UpdateChangesResponse()
        {
            Code = GroupDocsComparisonMvcDemo.Response.ResponseCode.Ok;
        }
    }

    [DataContract]
    public class UpdateChangesResult : Result
    {
        [XmlElement("result_file_Id")]
        [DataMember(Name = "result_file_Id")]
        public string ResultFileId { get; set; }
    }
}