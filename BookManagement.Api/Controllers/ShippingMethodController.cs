using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.CreateRole;
using BookManagement.Application.UseCases.Role_UseCase.DeleteRole;
using BookManagement.Application.UseCases.Role_UseCase.GetRole;
using BookManagement.Application.UseCases.Role_UseCase.GetRoleById;
using BookManagement.Application.UseCases.Role_UseCase.UpdateRole;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.CreateShippingMethod;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.DeleteShippingMethod;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.GetShippingMethod;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.GetShippingMethodById;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.UpdateShippingMethod;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ShippingMethodController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public ShippingMethodController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateShippingMethod([FromBody] CreateShippingMethodUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateShippingMethodUseCaseInput, CreateShippingMethodUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShippingMethods([FromQuery] GetShippingMethodUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetShippingMethodUseCaseInput, GetShippingMethodUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShippingMethodById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetShippingMethodByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateShippingMethod([FromBody] UpdateShippingMethodUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateShippingMethodUseCaseInput, UpdateShippingMethodUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteShippingMethod([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteShippingMethodUseCaseInput, DeleteShippingMethodUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteShippingMethodUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
