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

        public async Task<Missions> Get(int id)
        {
            return await dbContext.Missions
                .Where(x => x.Showonweb == "Y")
                .Where(x => x.Deleted == "N")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Missions>> GetUpcoming()
        {
            return await dbContext.Missions
              .Where(x => x.Einddatum > DateTime.Now)
              .Where(x => x.Deleted == "N")
              .Where(x => x.Showonweb == "Y")
              .OrderBy(x => x.Startdatum)
              .ToListAsync();
        }
    }
}
