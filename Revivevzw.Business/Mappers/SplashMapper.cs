using AutoMapper;
using Revivevzw.DataAccess;
using Revivevzw.DataContracts;

namespace Revivevzw.Business.Mappers
{
    public class SplashMapper : Profile
    {
        public SplashMapper()
        {
            CreateMap<Splashinfo, Splash>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Title, x => x.MapFrom(y => new Localization()
                {
                    Nl = y.TitelNl,
                    Fr = y.TitelFr,
                    En = y.TitelUk
                }))
                .ForMember(x => x.Url, x => x.MapFrom(y => y.SplashUrl));
        }
    }
}
