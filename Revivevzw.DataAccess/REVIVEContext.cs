using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Revivevzw.DataAccess
{
    public partial class REVIVEContext : DbContext
    {
        public REVIVEContext()
        {
        }

        public REVIVEContext(DbContextOptions<REVIVEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Betalingen> Betalingen { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Leden> Leden { get; set; }
        public virtual DbSet<Materiaal> Materiaal { get; set; }
        public virtual DbSet<Missions> Missions { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Pasfotos> Pasfotos { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Shoparticles> Shoparticles { get; set; }
        public virtual DbSet<Stgroepen> Stgroepen { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Betalingen>(entity =>
            {
                entity.ToTable("betalingen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bedrag)
                    .HasColumnName("bedrag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Doel)
                    .HasColumnName("doel")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LidId)
                    .HasColumnName("lidID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Opmerking)
                    .HasColumnName("opmerking")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Whochanged)
                    .IsRequired()
                    .HasColumnName("whochanged")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("countries");

                entity.Property(e => e.Capital)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cursymbol)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Fips104)
                    .IsRequired()
                    .HasColumnName("FIPS104")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iso2)
                    .IsRequired()
                    .HasColumnName("ISO2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iso3)
                    .IsRequired()
                    .HasColumnName("ISO3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Isono).HasColumnName("ISONo");

                entity.Property(e => e.LanguageIso)
                    .IsRequired()
                    .HasColumnName("languageISO")
                    .HasMaxLength(20);

                entity.Property(e => e.Regions)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tld)
                    .IsRequired()
                    .HasColumnName("TLD")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.ToTable("FILES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActId).HasColumnName("actID");

                entity.Property(e => e.ArtId).HasColumnName("artID");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Extentie)
                    .IsRequired()
                    .HasColumnName("extentie")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("file")
                    .HasColumnType("image")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('NL')");

                entity.Property(e => e.LidId).HasColumnName("lidID");

                entity.Property(e => e.Opmerking)
                    .IsRequired()
                    .HasColumnName("opmerking")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.UploadedBy).HasColumnName("uploadedBy");

                entity.Property(e => e.Volgorde).HasColumnName("volgorde");
            });

            modelBuilder.Entity<Leden>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aanspreek)
                    .HasColumnName("aanspreek")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Adres1)
                    .HasColumnName("adres1")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Adres2)
                    .HasColumnName("adres2")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Adres3)
                    .HasColumnName("adres3")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Beroep)
                    .HasColumnName("beroep")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Contactfrom)
                    .HasColumnName("contactfrom")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Email2)
                    .HasColumnName("email2")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Function)
                    .HasColumnName("function")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Geboren)
                    .HasColumnName("geboren")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Gemeente)
                    .HasColumnName("gemeente")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.Handschoen)
                    .HasColumnName("handschoen")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LandIso3)
                    .HasColumnName("landISO3")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('BEL')");

                entity.Property(e => e.Latexfree)
                    .HasColumnName("latexfree")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Naam)
                    .HasColumnName("naam")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Nieuwsbrief)
                    .HasColumnName("nieuwsbrief")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Opmerking)
                    .HasColumnName("opmerking")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.PasGeldigTot)
                    .HasColumnName("PasGeldigTOT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.PaspoortNo)
                    .HasColumnName("PaspoortNO")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Provincie)
                    .HasColumnName("provincie")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Rijksregnr)
                    .HasColumnName("rijksregnr")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Riziv)
                    .HasColumnName("riziv")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Schort)
                    .HasColumnName("schort")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Soortlid)
                    .HasColumnName("soortlid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Tel3)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Voornaam)
                    .HasColumnName("voornaam")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Materiaal>(entity =>
            {
                entity.ToTable("materiaal");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aankoopdatum)
                    .HasColumnName("aankoopdatum")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Aankoopprijs)
                    .HasColumnName("aankoopprijs")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Breedte)
                    .HasColumnName("breedte")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Eenheid)
                    .HasColumnName("eenheid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Gewicht)
                    .HasColumnName("gewicht")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Groep1)
                    .HasColumnName("groep1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Groep2)
                    .HasColumnName("groep2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hoogte)
                    .HasColumnName("hoogte")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lengte)
                    .HasColumnName("lengte")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Leverancier)
                    .HasColumnName("leverancier")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lijstnummer)
                    .HasColumnName("lijstnummer")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Naam)
                    .HasColumnName("naam")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Omschrijving)
                    .HasColumnName("omschrijving")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Opmerkingen)
                    .HasColumnName("opmerkingen")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Stockplaats)
                    .HasColumnName("stockplaats")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Vervaldatum)
                    .HasColumnName("vervaldatum")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Missions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActNaam)
                    .HasColumnName("actNaam")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.ActNaamEn)
                    .HasColumnName("actNaamEN")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.ActNaamFr)
                    .HasColumnName("actNaamFR")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Adreslijn1)
                    .HasColumnName("adreslijn1")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Adreslijn2)
                    .HasColumnName("adreslijn2")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("contactPhone")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Contactemail)
                    .HasColumnName("contactemail")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Einddatum)
                    .HasColumnName("einddatum")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.ExperienceFr)
                    .HasColumnName("experienceFR")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.ExperienceNl)
                    .HasColumnName("experienceNL")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.ExperienceUk)
                    .HasColumnName("experienceUK")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Extention)
                    .HasColumnName("extention")
                    .HasMaxLength(50);

                entity.Property(e => e.FlightInfo)
                    .HasColumnName("flightInfo")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Gemeente)
                    .HasColumnName("gemeente")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Instot)
                    .HasColumnName("INStot")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Insvanaf)
                    .HasColumnName("INSvanaf")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.InterventionsFr)
                    .HasColumnName("interventionsFR")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.InterventionsNl)
                    .HasColumnName("interventionsNL")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.InterventionsUk)
                    .HasColumnName("interventionsUK")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Land)
                    .HasColumnName("land")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("image");

                entity.Property(e => e.MissieOmschrijving)
                    .HasColumnName("missieOmschrijving")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.MissieOmschrijvingEn)
                    .HasColumnName("missieOmschrijvingEN")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.MissieOmschrijvingFr)
                    .HasColumnName("missieOmschrijvingFR")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Missionleader)
                    .HasColumnName("missionleader")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Missionsort)
                    .HasColumnName("missionsort")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OnlineInschrijven)
                    .HasColumnName("onlineInschrijven")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Prijs)
                    .HasColumnName("prijs")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Prijsvariable)
                    .HasColumnName("prijsvariable")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ReportDoneBy)
                    .HasColumnName("reportDoneBy")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReportFr)
                    .HasColumnName("reportFR")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.ReportNl)
                    .HasColumnName("reportNL")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.ReportUk)
                    .HasColumnName("reportUK")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.ShowReportOnWeb)
                    .HasColumnName("showReportOnWeb")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Showonweb)
                    .HasColumnName("showonweb")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Startdatum)
                    .HasColumnName("startdatum")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.VraagAdres)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WebMainPicture)
                    .HasColumnName("webMainPicture")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Afschrift)
                    .HasColumnName("afschrift")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Artid)
                    .HasColumnName("ARTID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Betaald)
                    .HasColumnName("betaald")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BetaaldOp)
                    .HasColumnName("betaaldOP")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GeleverdOp)
                    .HasColumnName("geleverdOP")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Maat)
                    .HasColumnName("maat")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.MededelingOv)
                    .HasColumnName("mededelingOV")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.MemberId)
                    .HasColumnName("memberID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Opmerking).HasColumnName("opmerking");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Rappeldatum)
                    .HasColumnName("rappeldatum")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.RekNr)
                    .HasColumnName("rekNr")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.StrucMsg)
                    .HasColumnName("strucMSG")
                    .HasMaxLength(50);

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Participants>(entity =>
            {
                entity.ToTable("participants");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activity)
                    .HasColumnName("activity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Afschrift)
                    .HasColumnName("afschrift")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Altfrom)
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Altto)
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Betaald1)
                    .HasColumnName("betaald1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BetaaldOp)
                    .HasColumnName("betaaldOP")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Bigremark)
                    .HasColumnName("bigremark")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Groep)
                    .HasColumnName("groep")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MededelingOv)
                    .HasColumnName("mededelingOV")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.MemberId)
                    .HasColumnName("memberID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Missionfunction)
                    .HasColumnName("missionfunction")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RekNr)
                    .HasColumnName("rekNr")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Smallremark)
                    .HasColumnName("smallremark")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.StrucMsg)
                    .HasColumnName("strucMSG")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Pasfotos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActId).HasColumnName("actID");

                entity.Property(e => e.ArtId).HasColumnName("artID");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Extentie)
                    .IsRequired()
                    .HasColumnName("extentie")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnName("foto")
                    .HasColumnType("image");

                entity.Property(e => e.LidId).HasColumnName("lidID");

                entity.Property(e => e.Opmerking)
                    .IsRequired()
                    .HasColumnName("opmerking")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.UploadedBy)
                    .IsRequired()
                    .HasColumnName("uploadedBy")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Volgorde).HasColumnName("volgorde");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.FactoryId)
                    .HasColumnName("FactoryID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Keys)
                    .HasColumnName("keys")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.N0).HasDefaultValueSql("((0))");

                entity.Property(e => e.N1).HasDefaultValueSql("((0))");

                entity.Property(e => e.N10).HasDefaultValueSql("((0))");

                entity.Property(e => e.N11).HasDefaultValueSql("((0))");

                entity.Property(e => e.N12).HasDefaultValueSql("((0))");

                entity.Property(e => e.N13).HasDefaultValueSql("((0))");

                entity.Property(e => e.N14).HasDefaultValueSql("((0))");

                entity.Property(e => e.N2).HasDefaultValueSql("((0))");

                entity.Property(e => e.N3).HasDefaultValueSql("((0))");

                entity.Property(e => e.N4).HasDefaultValueSql("((0))");

                entity.Property(e => e.N5).HasDefaultValueSql("((0))");

                entity.Property(e => e.N6).HasDefaultValueSql("((0))");

                entity.Property(e => e.N7).HasDefaultValueSql("((0))");

                entity.Property(e => e.N8).HasDefaultValueSql("((0))");

                entity.Property(e => e.N9).HasDefaultValueSql("((0))");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Short)
                    .HasColumnName("short")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Tnumber)
                    .HasColumnName("tnumber")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.V0).HasDefaultValueSql("('')");

                entity.Property(e => e.V1).HasDefaultValueSql("('')");

                entity.Property(e => e.V10).HasDefaultValueSql("('')");

                entity.Property(e => e.V11).HasDefaultValueSql("('')");

                entity.Property(e => e.V12).HasDefaultValueSql("('')");

                entity.Property(e => e.V13).HasDefaultValueSql("('')");

                entity.Property(e => e.V14).HasDefaultValueSql("('')");

                entity.Property(e => e.V2).HasDefaultValueSql("('')");

                entity.Property(e => e.V3).HasDefaultValueSql("('')");

                entity.Property(e => e.V4).HasDefaultValueSql("('')");

                entity.Property(e => e.V5).HasDefaultValueSql("('')");

                entity.Property(e => e.V6).HasDefaultValueSql("('')");

                entity.Property(e => e.V7).HasDefaultValueSql("('')");

                entity.Property(e => e.V8).HasDefaultValueSql("('')");

                entity.Property(e => e.V9).HasDefaultValueSql("('')");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(50);

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Shoparticles>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SHOParticles");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Maten)
                    .HasColumnName("maten")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Omskort)
                    .HasColumnName("omskort")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Omslang)
                    .HasColumnName("omslang")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Portkosten)
                    .HasColumnName("portkosten")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Portvrijvanaf)
                    .HasColumnName("portvrijvanaf")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Prijs)
                    .HasColumnName("prijs")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Publish)
                    .HasColumnName("publish")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Sortorder)
                    .HasColumnName("sortorder")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tooninlijst)
                    .HasColumnName("tooninlijst")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.WieMailen).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Stgroepen>(entity =>
            {
                entity.ToTable("STgroepen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Groep)
                    .HasColumnName("groep")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mastergroep)
                    .HasColumnName("mastergroep")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NameFr)
                    .HasColumnName("nameFR")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.NameNl)
                    .HasColumnName("nameNL")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.NameUk)
                    .HasColumnName("nameUK")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Opmerking)
                    .HasColumnName("opmerking")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("STOCK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aankoopprijs)
                    .HasColumnName("aankoopprijs")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Aantal)
                    .HasColumnName("aantal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("articleID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Eenheid)
                    .HasColumnName("eenheid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Kolom)
                    .HasColumnName("kolom")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Leverancier)
                    .HasColumnName("leverancier")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lokaal)
                    .HasColumnName("lokaal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Merk)
                    .HasColumnName("merk")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Opmerking)
                    .HasColumnName("opmerking")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Rek)
                    .HasColumnName("rek")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Rij)
                    .HasColumnName("rij")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Steriel)
                    .HasColumnName("steriel")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Vakje)
                    .HasColumnName("vakje")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Vervaldatum)
                    .HasColumnName("vervaldatum")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01/01/1900')");

                entity.Property(e => e.Whochanged)
                    .HasColumnName("whochanged")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Admin)
                    .IsRequired()
                    .HasColumnName("admin")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Dchanged)
                    .HasColumnName("dchanged")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dcreated)
                    .HasColumnName("dcreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnName("deleted")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Gsm)
                    .IsRequired()
                    .HasColumnName("GSM")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Language).HasColumnName("language");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.Whochanged)
                    .IsRequired()
                    .HasColumnName("whochanged")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(space((0)))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
