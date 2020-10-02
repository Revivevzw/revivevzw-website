using AutoMapper;
using Revivevzw.Business.Repositories;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository sponsorRepository;
        private readonly IMapper mapper;

        public SponsorService(ISponsorRepository sponsorRepository, IMapper mapper)
        {
            this.sponsorRepository = sponsorRepository ?? throw new ArgumentNullException(nameof(sponsorRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Sponsor> Get(int id)
        {
            var entity = await this.sponsorRepository.Get(id);
            return this.mapper.Map<Sponsor>(entity);
        }

        public async Task<IEnumerable<Sponsor>> Get()
        {
            var entity = await this.sponsorRepository.Get();
            return this.mapper.Map<IEnumerable<Sponsor>>(entity);
        }
    }
}
