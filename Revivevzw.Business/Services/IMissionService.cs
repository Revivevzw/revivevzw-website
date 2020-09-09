using Revivevzw.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public interface IMissionService
    {
        Task<ICollection<Mission>> Get();
        Task<Mission> Get(int id);
    }
}