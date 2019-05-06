using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VasilyTest.Core.Services;
using VasilyTest.DTO;

namespace VasilyTest.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var files = await _testService.GetAllModelsAsync();
            return ReturnResult(files);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TestDbModelDTO model)
        {
            var result = await _testService.AddModelAsync(model);
            return ReturnResult(result);
        }
    }
}
