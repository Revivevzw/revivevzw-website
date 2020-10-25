using AutoMapper;
using Revivevzw.Business.Repositories;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public class SplashService : ISplashService
    {
        private readonly ISplashRepository splashRepository;
        private readonly IMapper mapper;

        public SplashService(ISplashRepository splashRepository, IMapper mapper)
        {
            this.splashRepository = splashRepository ?? throw new ArgumentNullException(nameof(splashRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Splash>> Get()
        {
            var entity = await this.splashRepository.Get();
            return this.mapper.Map<IEnumerable<Splash>>(entity);
        }
    }
}
