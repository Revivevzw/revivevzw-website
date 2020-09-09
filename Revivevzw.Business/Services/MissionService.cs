using AutoMapper;
using Revivevzw.Business.Repositories;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public class MissionService : IMissionService
    {
        private readonly IMissionRepository missionRepository;
        private readonly IMapper mapper;

        public MissionService(IMissionRepository missionRepository, IMapper mapper)
        {
            this.missionRepository = missionRepository ?? throw new ArgumentNullException(nameof(missionRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Mission> Get(int id)
        {
            var entity = await this.missionRepository.Get(id);
            return this.mapper.Map<Mission>(entity);
        }

        public async Task<ICollection<Mission>> Get()
        {
            var entities = await this.missionRepository.Get();
            return this.mapper.Map<ICollection<Mission>>(entities);
        }
    }
}
