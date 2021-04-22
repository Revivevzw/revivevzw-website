using AutoMapper;
using Revivevzw.Business.Repositories;
using Revivevzw.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository settingRepository;
        private readonly IMapper mapper;
        //private readonly IConfiguration configuration;

        public SettingService(ISettingRepository settingRepository, IMapper mapper/*, IConfiguration configuration*/)
        {
            this.settingRepository = settingRepository ?? throw new ArgumentNullException(nameof(settingRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            //this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<Settings> GetOrganigramURL()
        {
            var entity = await settingRepository.Get("ORGANIGRAM");
            var url = entity.FirstOrDefault();
            return url;
        }
    }
}
