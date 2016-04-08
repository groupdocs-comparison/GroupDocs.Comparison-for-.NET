using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GroupDocsComparisonMvcDemo.Response
{
    [XmlRoot(Namespace = "")]
    [DataContract()]
    public class Response<TResult>
        where TResult : IResult, new()
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public Response()
        {
            Result = new TResult();
            ComposedOn = DateTime.UtcNow;
        }

        public ResponseCode Code { get; set; }

        [XmlElement("result")]
        [DataMember(Name = "result")]
        public TResult Result { get; set; }

        [XmlElement("status")]
        [DataMember(Name = "status")]
        public string Status
        {
            get { return Code.ToString(); }
            set
            {
                try
                {
                    Code = (ResponseCode) Enum.Parse(typeof(ResponseCode), value);
                }
                catch { }
            }
        }

        [XmlElement("error_message", IsNullable = false)]
        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }

        [XmlElement("composedOn")]
        [DataMember(Name = "composedOn")]
        public long ComposedOnJS
        {
            get { return (long) (ComposedOn - Epoch).TotalMilliseconds; }
            set { ComposedOn = Epoch.AddMilliseconds(value); }
        }

        public DateTime ComposedOn { get; private set; }
    }

    public interface IResult
    {
    }

    [DataContract()]
    public class Result : IResult
    {
    }
}