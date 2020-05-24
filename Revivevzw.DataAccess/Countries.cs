using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Countries
    {
        public int Id { get; set; }
        public string Tld { get; set; }
        public string Country { get; set; }
        public string Fips104 { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public double Isono { get; set; }
        public string Capital { get; set; }
        public string Regions { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string Cursymbol { get; set; }
        public double Population { get; set; }
        public string LanguageIso { get; set; }
        public string Deleted { get; set; }
    }
}
