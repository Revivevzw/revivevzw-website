using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Participants
    {
        public int Id { get; set; }
        public int? Activity { get; set; }
        public int? Groep { get; set; }
        public int? MemberId { get; set; }
        public string Smallremark { get; set; }
        public string Bigremark { get; set; }
        public DateTime? Altfrom { get; set; }
        public DateTime? Altto { get; set; }
        public int? Missionfunction { get; set; }
        public string StrucMsg { get; set; }
        public double? Betaald { get; set; }
        public double? Betaald1 { get; set; }
        public DateTime? BetaaldOp { get; set; }
        public string Afschrift { get; set; }
        public string RekNr { get; set; }
        public string MededelingOv { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
