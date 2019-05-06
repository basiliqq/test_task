using VasilyTest.Core.Helpers;
using VasilyTest.DTO;
using VasilyTest.Models;

namespace VasilyTest.Core.Services
{
    public interface IAuthService
    {
        RequestResult<string> Authenticate(string username, string password);
    }
}
