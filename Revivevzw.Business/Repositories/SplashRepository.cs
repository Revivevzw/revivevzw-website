using Microsoft.EntityFrameworkCore;
using Revivevzw.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
    public class SplashRepository : ISplashRepository
    {
        private readonly REVIVEContext context;

        public SplashRepository(REVIVEContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private IQueryable<Splashinfo> GetForWeb()
        {
            return this.context.Set<Splashinfo>().Where(x => x.ShowOnWeb == "Y");
        }

        public async Task<IEnumerable<Splashinfo>> Get()
        {
            return await GetForWeb().ToListAsync();
        }
    }
}
