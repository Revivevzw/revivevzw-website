using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Shoparticles
    {
        public int Id { get; set; }
        public string Omskort { get; set; }
        public string Omslang { get; set; }
        public double? Prijs { get; set; }
        public double? Inkoopprijs { get; set; }
        public string Maten { get; set; }
        public int? Portvrijvanaf { get; set; }
        public double? Portkosten { get; set; }
        public int? Stock { get; set; }
        public string Publish { get; set; }
        public int? WieMailen { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
        public int? Sortorder { get; set; }
        public string Tooninlijst { get; set; }
        public string Instatistiek { get; set; }
    }
}
