using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VasilyTest.Core.Helpers;
using VasilyTest.DataAccess.UoW;
using VasilyTest.DTO;
using VasilyTest.Models;

namespace VasilyTest.Core.Services.Impl
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _uow;

        public TestService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<RequestResult<IEnumerable<TestDbModelDTO>>> GetAllModelsAsync()
        {
            var result = new RequestResult<IEnumerable<TestDbModelDTO>>();

            try
            {
                var files = await _uow.Repository<TestDbModel>().GetAllAsync();

                result.Obj = files.Select(x => new TestDbModelDTO { Name = x.Name });
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.StatusCode = StatusCodes.Status500InternalServerError;
            }

            return result;
        }

        public async Task<RequestResult> AddModelAsync(TestDbModelDTO model)
        {
            var result = new RequestResult();

            if (model == null)
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Message = "There is no model in request";
                return result;
            }

            try
            {
                var dbModel = new TestDbModel
                {
                    Name = model.Name
                };

                await _uow.Repository<TestDbModel>().AddAsync(dbModel);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.StatusCode = StatusCodes.Status500InternalServerError;
            }

            return result;
        }
    }
}
