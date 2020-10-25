using Revivevzw.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public interface ISplashService
    {
        Task<IEnumerable<Splash>> Get();
    }
}