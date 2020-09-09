using System;
using System.Runtime.Serialization;

namespace Revivevzw.DataContracts
{
    [DataContract]
    public class Mission
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public Localization Name { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "description")]
        public Localization Description { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime? StartDate { get; set; }

        [DataMember(Name = "endDate")]
        public DateTime? EndDate { get; set; }

        [DataMember(Name = "report")]
        public Localization Report { get; set; }

        [DataMember(Name = "interventions")]
        public Localization Interventions { get; set; }

        [DataMember(Name = "mainImage")]
        public string MainImage { get; set; }
    }
}
