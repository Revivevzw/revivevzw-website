using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Leden
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public int? Aanspreek { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string Adres3 { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Provincie { get; set; }
        public string LandIso3 { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Gender { get; set; }
        public int? Beroep { get; set; }
        public string Opmerking { get; set; }
        public string Rijksregnr { get; set; }
        public string Riziv { get; set; }
        public string PaspoortNo { get; set; }
        public DateTime? PasGeldigTot { get; set; }
        public int? Contactfrom { get; set; }
        public int? Function { get; set; }
        public int? Soortlid { get; set; }
        public string Nieuwsbrief { get; set; }
        public int? Handschoen { get; set; }
        public int? Schort { get; set; }
        public string Latexfree { get; set; }
        public DateTime? Geboren { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
