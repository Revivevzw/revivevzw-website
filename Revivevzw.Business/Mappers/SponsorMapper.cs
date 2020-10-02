using AutoMapper;
using Revivevzw.DataAccess;

namespace Revivevzw.Business.Mappers
{
    public class SponsorMapper : Profile
    {
        public SponsorMapper()
        {
            CreateMap<Sponsors, DataContracts.Sponsor>()
                .ForMember(x => x.LogoUrl, x => x.MapFrom(y => y.PicUrl))
                .ForMember(x => x.Amount, x => x.MapFrom(y => y.Bedrag))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Naam));
        }
    }
}
