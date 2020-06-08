using Revivevzw.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
    public interface IActivityRepository
    {
        Task<Missions> Get(int id);
        Task<ICollection<Missions>> GetUpcoming();
    }
}
