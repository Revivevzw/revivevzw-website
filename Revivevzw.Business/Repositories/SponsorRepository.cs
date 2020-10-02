using Microsoft.EntityFrameworkCore;
using Revivevzw.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly REVIVEContext dbContext;

        public SponsorRepository(REVIVEContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private IQueryable<Sponsors> GetForWeb()
        {
            return this.dbContext.Set<Sponsors>()
                .Where(x => x.Deleted == "N")
                .Where(x => x.ShowOnWeb == "Y");
        }

        public async Task<Sponsors> Get(int id)
        {
            return await GetForWeb().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Sponsors>> Get()
        {
            return await GetForWeb().ToListAsync();
        }
    }
}
