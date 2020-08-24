using Revivevzw.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Revivevzw.DataContracts
{
    [DataContract]
    public class Activity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "type")]
        public ActivityType? Type { get; set; }
        [DataMember(Name = "name")]
        public Localization Name { get; set; }
        [DataMember(Name = "description")]
        public Localization Description { get; set; }
        [DataMember(Name = "street")]
        public string Street { get; set; }
        [DataMember(Name = "postalCode")]
        public string PostalCode { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "country")]
        public string Country { get; set; }
        [DataMember(Name = "startDate")]
        public DateTime? StartDate { get; set; }
        [DataMember(Name = "endDate")]
        public DateTime? EndDate { get; set; }

        [DataMember(Name = "canRegisterOnline")]
        public bool CanRegisterOnline { get; set; }
    }
}
