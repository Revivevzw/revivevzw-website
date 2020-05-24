using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Files
    {
        public int Id { get; set; }
        public int LidId { get; set; }
        public int ActId { get; set; }
        public int ArtId { get; set; }
        public DateTime Datum { get; set; }
        public byte[] File { get; set; }
        public string Language { get; set; }
        public string Extentie { get; set; }
        public string Filename { get; set; }
        public int UploadedBy { get; set; }
        public string Opmerking { get; set; }
        public int Volgorde { get; set; }
    }
}
