using System.Runtime.Serialization;

namespace Revivevzw.DataContracts
{
    [DataContract]
    public class Mail
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "emailFrom")]
        public string EmailFrom { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
