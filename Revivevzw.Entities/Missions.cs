using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Missions
    {
        public int Id { get; set; }
        public int? Missionsort { get; set; }
        public string ActNaam { get; set; }
        public string ActNaamFr { get; set; }
        public string ActNaamEn { get; set; }
        public string Adreslijn1 { get; set; }
        public string Adreslijn2 { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Land { get; set; }
        public string MissieOmschrijving { get; set; }
        public string MissieOmschrijvingFr { get; set; }
        public string MissieOmschrijvingEn { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Einddatum { get; set; }
        public DateTime? Insvanaf { get; set; }
        public DateTime? Instot { get; set; }
        public double? Prijs { get; set; }
        public string Prijsvariable { get; set; }
        public string Online { get; set; }
        public string Showonweb { get; set; }
        public string OnlineInschrijven { get; set; }
        public string VraagAdres { get; set; }
        public byte[] Logo { get; set; }
        public string Extention { get; set; }
        public string Contact { get; set; }
        public string Contactemail { get; set; }
        public string ContactPhone { get; set; }
        public int? Missionleader { get; set; }
        public string FlightInfo { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
