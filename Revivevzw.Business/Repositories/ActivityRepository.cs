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

    public async Task<ICollection<Missions>> GetUpcoming()
    {
      return await dbContext.Missions
        .Where(x => x.Einddatum > DateTime.Now)
        .Where(x => string.IsNullOrEmpty(x.Deleted))
        .OrderBy(x => x.Startdatum)
        .ToListAsync();
    }
  }
}
