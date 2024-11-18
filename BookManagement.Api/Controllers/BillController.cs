using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Bill_UseCase.CreateBill;
using BookManagement.Application.UseCases.Bill_UseCase.GetBillById;
using BookManagement.Application.UseCases.Book_UseCase.CreateBook;
using BookManagement.Application.UseCases.Book_UseCase.DeleteBook;
using BookManagement.Application.UseCases.Book_UseCase.GetBook;
using BookManagement.Application.UseCases.Book_UseCase.GetBookById;
using BookManagement.Application.UseCases.Book_UseCase.UpdateBook;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public BillController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateBillUseCaseInput, CreateBillUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetBillByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
