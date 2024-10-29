using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.CreateBook;
using BookManagement.Application.UseCases.Book_UseCase.DeleteBook;
using BookManagement.Application.UseCases.Book_UseCase.GetBook;
using BookManagement.Application.UseCases.Book_UseCase.GetBookById;
using BookManagement.Application.UseCases.Book_UseCase.UpdateBook;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.CreateDiscountEvent;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.DeleteDiscountEvent;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEvent;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEventById;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.UpdateDiscountEvent;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public BookController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteBook([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteBookUseCaseInput, DeleteBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteBookUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateBookUseCaseInput, CreateBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateBook([FromForm] UpdateBookUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateBookUseCaseInput, UpdateBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery] GetBookUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetBookUseCaseInput, GetBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetBookByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
