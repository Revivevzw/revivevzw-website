using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Stgroepen
    {
        public int Id { get; set; }
        public int? Groep { get; set; }
        public int? Mastergroep { get; set; }
        public string NameNl { get; set; }
        public string NameFr { get; set; }
        public string NameUk { get; set; }
        public string Opmerking { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
