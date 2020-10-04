using System.Runtime.Serialization;

namespace Revivevzw.DataContracts
{
    [DataContract]
    public class Splash
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public Localization Title { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
