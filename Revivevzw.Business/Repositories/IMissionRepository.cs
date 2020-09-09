using Revivevzw.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
    public interface IMissionRepository
    {
        Task<ICollection<Missions>> Get();
        Task<Missions> Get(int id);
    }
}