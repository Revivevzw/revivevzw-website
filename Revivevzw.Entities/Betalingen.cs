using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Betalingen
    {
        public int Id { get; set; }
        public int? LidId { get; set; }
        public double? Bedrag { get; set; }
        public int? Doel { get; set; }
        public DateTime? Datum { get; set; }
        public string Opmerking { get; set; }
        public string Deleted { get; set; }
        public DateTime Dcreated { get; set; }
        public DateTime Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
