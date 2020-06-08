using AutoMapper;
using Revivevzw.Business.Repositories;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository missionRepository;
        private readonly IMapper mapper;

        public ActivityService(IActivityRepository missionRepository, IMapper mapper)
        {
            this.missionRepository = missionRepository;
            this.mapper = mapper;
        }

        public async Task<Activity> Get(int id)
        {
            var mission = await missionRepository.Get(id);
            return mapper.Map<Activity>(mission);
        }

        public async Task<ICollection<Activity>> GetUpcoming()
        {
            var missions = await missionRepository.GetUpcoming();
            return mapper.Map<ICollection<Activity>>(missions);
        }
    }
}
