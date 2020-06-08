using Revivevzw.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public interface IActivityService
    {
        Task<Activity> Get(int id);
        Task<ICollection<Activity>> GetUpcoming();
    }
}
