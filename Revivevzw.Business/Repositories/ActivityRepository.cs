using Microsoft.EntityFrameworkCore;
using Revivevzw.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly REVIVEContext dbContext;

        public ActivityRepository(REVIVEContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IQueryable<Missions> GetForWeb()
        {
            return dbContext.Set<Missions>()
                .Where(x => x.Showonweb == "Y")
                .Where(x => x.Deleted == "N");
        }

        public async Task<Missions> Get(int id)
        {
            return await GetForWeb()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Missions>> GetUpcoming()
        {
            return await GetForWeb()
              .Where(x => x.Einddatum > DateTime.Now)
              .OrderBy(x => x.Startdatum)
              .ToListAsync();
        }
    }
}
