using System.Runtime.Serialization;

namespace Revivevzw.DataContracts
{
    [DataContract]
    public class SubscribeRequest
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}
