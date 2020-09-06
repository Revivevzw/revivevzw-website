using AutoMapper;
using Revivevzw.DataAccess;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revivevzw.Business.Mappers
{
  public class ActivityMapper : Profile
  {
    public ActivityMapper()
    {
            // Een kleine toelichting waarom er weinig logica zit tussen Database model en DataContract:
            // Database bestaat reeds (gemaakt door Erik) en deze is vrij onlogisch obgebouwd.
            // Er wordt geen consequente/ logische naamgeving gebruikt.
            // Missies wordt gezien als een algemeen object waar zowel missies als activiteiten etc in zitten.

            CreateMap<Missions, DataContracts.Activity>()
              .ForMember(x => x.Name, x => x.MapFrom(y => new Localization()
              {
                  Nl = y.ActNaam,
                  En = y.ActNaamEn,
                  Fr = y.ActNaamFr
              }))
              .ForMember(x => x.Description, x => x.MapFrom(y => new Localization()
              {
                  Nl = y.MissieOmschrijving,
                  En = y.MissieOmschrijvingEn,
                  Fr = y.MissieOmschrijvingFr
              }))
              .ForMember(x => x.City, x => x.MapFrom(y => y.Gemeente))
              .ForMember(x => x.Country, x => x.MapFrom(y => y.Land))
              .ForMember(x => x.StartDate, x => x.MapFrom(y => y.Startdatum))
              .ForMember(x => x.EndDate, x => x.MapFrom(y => y.Einddatum))
              .ForMember(x => x.Street, x => x.MapFrom(y => y.Adreslijn1))
              .ForMember(x => x.PostalCode, x => x.MapFrom(y => y.Postcode))
              .ForMember(x => x.Type, x => x.MapFrom(y => y.Missionsort))
              .ForMember(x => x.CanRegisterOnline, x => x.MapFrom(y => y.OnlineInschrijven == "Y"));
    }
  }
}
