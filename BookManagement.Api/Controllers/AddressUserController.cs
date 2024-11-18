using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.AddressUser_UseCase.CreateAddressUser;
using BookManagement.Application.UseCases.AddressUser_UseCase.DeleteAddressUser;
using BookManagement.Application.UseCases.AddressUser_UseCase.GetAddressUser;
using BookManagement.Application.UseCases.AddressUser_UseCase.GetAddressUserById;
using BookManagement.Application.UseCases.AddressUser_UseCase.GetAddressUserByUserId;
using BookManagement.Application.UseCases.AddressUser_UseCase.UpdateAddressUser;
using BookManagement.Application.UseCases.Book_UseCase.CreateBook;
using BookManagement.Application.UseCases.Book_UseCase.DeleteBook;
using BookManagement.Application.UseCases.Book_UseCase.GetBook;
using BookManagement.Application.UseCases.Book_UseCase.GetBookById;
using BookManagement.Application.UseCases.Book_UseCase.UpdateBook;
using BookManagement.Application.UseCases.CartItem_UseCase.GetCartByUserId;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AddressUserController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public AddressUserController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateAddressUser([FromBody] CreateAddressUserUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateAddressUserUseCaseInput, CreateAddressUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateAddressUser([FromBody] UpdateAddressUserUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateAddressUserUseCaseInput, UpdateAddressUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddressUsers([FromQuery] GetAddressUserUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetAddressUserUseCaseInput, GetAddressUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressUserById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetAddressUserByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressUserByUserId([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetAddressUserByUserIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteAddressUser([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteAddressUserUseCaseInput, DeleteAddressUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteAddressUserUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
