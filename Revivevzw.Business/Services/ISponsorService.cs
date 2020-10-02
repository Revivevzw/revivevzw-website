using Revivevzw.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public interface ISponsorService
    {
        Task<IEnumerable<Sponsor>> Get();
        Task<Sponsor> Get(int id);
    }
}