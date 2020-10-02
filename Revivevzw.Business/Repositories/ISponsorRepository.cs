using Revivevzw.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Repositories
{
    public interface ISponsorRepository
    {
        Task<IEnumerable<Sponsors>> Get();
        Task<Sponsors> Get(int id);
    }
}