using System;
using System.Runtime.Serialization;

namespace Revivevzw.DataContracts
{
    [DataContract]
    public class Sponsor
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "websiteUrl")]
        public string WebsiteUrl { get; set; }

        [DataMember(Name = "logoUrl")]
        public string LogoUrl { get; set; }

        [DataMember(Name = "amount")]
        public double? Amount { get; set; }

        [DataMember(Name = "endDate")]
        public DateTime? EndDate { get; set; }
    }
}
