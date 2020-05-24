using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? Artid { get; set; }
        public int? MemberId { get; set; }
        public double? Price { get; set; }
        public string Maat { get; set; }
        public int? Quantity { get; set; }
        public string StrucMsg { get; set; }
        public double? Betaald { get; set; }
        public DateTime? BetaaldOp { get; set; }
        public DateTime? Rappeldatum { get; set; }
        public DateTime? GeleverdOp { get; set; }
        public string Afschrift { get; set; }
        public string RekNr { get; set; }
        public string MededelingOv { get; set; }
        public string Opmerking { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
