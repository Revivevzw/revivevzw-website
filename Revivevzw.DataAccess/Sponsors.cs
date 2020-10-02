using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Sponsors
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int? ContactInfo { get; set; }
        public double? Bedrag { get; set; }
        public string ShowOnWeb { get; set; }
        public DateTime? EndDate { get; set; }
        public string PicUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string Opmerking { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
