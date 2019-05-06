using System.Collections.Generic;
using System.Threading.Tasks;
using VasilyTest.Core.Helpers;
using VasilyTest.DTO;

namespace VasilyTest.Core.Services
{
    public interface ITestService
    {
        Task<RequestResult<IEnumerable<TestDbModelDTO>>> GetAllModelsAsync();
        Task<RequestResult> AddModelAsync(TestDbModelDTO file);
    }
}
