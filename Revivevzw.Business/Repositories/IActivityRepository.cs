using Revivevzw.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
  public interface IActivityRepository
  {
    Task<ICollection<Missions>> GetUpcoming();
  }
}
