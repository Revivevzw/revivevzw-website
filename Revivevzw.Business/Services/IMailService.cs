using Revivevzw.DataContracts;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public interface IMailService
    {
        Task Send(Mail mail);
    }
}