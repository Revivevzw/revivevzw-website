﻿using AutoMapper;
using Revivevzw.DataAccess;
using Revivevzw.DataContracts;
using Revivevzw.Enums;
using System;

namespace Revivevzw.Business.Mappers
{
    public class MissionMapper : Profile
    {
        public MissionMapper()
        {
            CreateMap<Missions, DataContracts.Mission>()
                .ForMember(x => x.Interventions, x => x.MapFrom(y => new Localization()
                {
                    Nl = y.InterventionsNl,
                    Fr = y.InterventionsFr,
                    En = y.InterventionsUk
                }))
                .ForMember(x => x.Report, x => x.MapFrom(y => new Localization()
                {
                    Nl = y.ReportNl,
                    Fr = y.ReportFr,
                    En = y.ReportUk
                }))
                .ForMember(x => x.Name, x => x.MapFrom(y => new Localization()
                {
                    Nl = y.ActNaam,
                    Fr = y.ActNaamFr,
                    En = y.ActNaamEn
                }))
                .ForMember(x => x.Description, x => x.MapFrom(y => new Localization()
                {
                    Nl = y.MissieOmschrijving,
                    Fr = y.MissieOmschrijvingFr,
                    En = y.MissieOmschrijvingEn
                }))
                .ForMember(x => x.Quote, x => x.MapFrom(y => new Localization()
                {
                    Nl = y.ExperienceNl,
                    Fr = y.ExperienceFr,
                    En = y.ExperienceUk
                }))
                .ForMember(x => x.Country, x => x.MapFrom(y => y.Land))
                .ForMember(x => x.StartDate, x => x.MapFrom(y => y.Startdatum))
                .ForMember(x => x.EndDate, x => x.MapFrom(y => y.Einddatum))
                .ForMember(x => x.ShowReport, x => x.MapFrom(y => y.ShowReportOnWeb == "Y"))
                .ForMember(x => x.MainImage, x => x.MapFrom(y => y.WebMainPicture))
                .ForMember(x => x.Type, x => x.MapFrom(y =>
                    y.Missionsort == (int)ActivityType.Mission
                        ? y.Einddatum >= DateTime.Now
                            ? DTOActivityType.PlannedMission
                            : DTOActivityType.PastMission
                        : y.Einddatum >= DateTime.Now
                            ? DTOActivityType.PlannedScouting
                            : DTOActivityType.PastScouting));
        }
    }
}
