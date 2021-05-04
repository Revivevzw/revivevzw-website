using Revivevzw.DataAccess;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public interface ISettingService
    {
        Task<Settings> GetOrganigramURL();
    }
}