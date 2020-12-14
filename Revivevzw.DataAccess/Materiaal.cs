using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Materiaal
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Opmerkingen { get; set; }
        public DateTime? Aankoopdatum { get; set; }
        public double? Aankoopprijs { get; set; }
        public int? Leverancier { get; set; }
        public string BestelId { get; set; }
        public double? Gewicht { get; set; }
        public double? Lengte { get; set; }
        public double? Breedte { get; set; }
        public double? Hoogte { get; set; }
        public int? Groep1 { get; set; }
        public int? Groep2 { get; set; }
        public DateTime? Vervaldatum { get; set; }
        public int? Eenheid { get; set; }
        public int? Lijstnummer { get; set; }
        public string Stockplaats { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
