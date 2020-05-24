using Revivevzw.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
  public interface IActivityService
  {
    Task<ICollection<Activity>> GetUpcoming();
  }
}
