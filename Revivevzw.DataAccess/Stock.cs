using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public int? Leverancier { get; set; }
        public int? Merk { get; set; }
        public int? Lokaal { get; set; }
        public string Rek { get; set; }
        public string Kolom { get; set; }
        public string Rij { get; set; }
        public string Vakje { get; set; }
        public double? Aantal { get; set; }
        public int? Eenheid { get; set; }
        public string Steriel { get; set; }
        public double? Aankoopprijs { get; set; }
        public string Opmerking { get; set; }
        public DateTime? Vervaldatum { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
