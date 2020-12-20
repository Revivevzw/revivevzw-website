using Microsoft.EntityFrameworkCore;
using Revivevzw.DataAccess;
using Revivevzw.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly REVIVEContext dbContext;

        public MissionRepository(REVIVEContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private IQueryable<Missions> GetApplicable()
        {
            return dbContext.Set<Missions>()
                .Where(x => x.Missionsort == (int)ActivityType.Mission)
                .Where(x => x.Einddatum < DateTime.Now)
                .Where(x => x.ShowReportOnWeb == "Y")
                .Where(x => x.Deleted == "N");
        }

        public async Task<Missions> Get(int id)
        {
            return await GetApplicable()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Missions>> Get()
        {
            return await GetApplicable().ToListAsync();
        }
    }
}
