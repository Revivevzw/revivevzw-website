using Microsoft.EntityFrameworkCore;
using Revivevzw.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly REVIVEContext dbContext;

        public SettingRepository(REVIVEContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<IEnumerable<Settings>> Get(string key)
        {
            return await dbContext.Set<Settings>()
                .Where(x => x.Keys == key).ToListAsync();
        }
    }
}
