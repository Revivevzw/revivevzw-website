using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Pasfotos
    {
        public int Id { get; set; }
        public int LidId { get; set; }
        public int ActId { get; set; }
        public int ArtId { get; set; }
        public DateTime Datum { get; set; }
        public byte[] Foto { get; set; }
        public string UploadedBy { get; set; }
        public string Extentie { get; set; }
        public string Opmerking { get; set; }
        public int Volgorde { get; set; }
    }
}
