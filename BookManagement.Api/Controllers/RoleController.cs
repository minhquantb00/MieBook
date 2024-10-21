using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Category_UseCase.GetCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategoryById;
using BookManagement.Application.UseCases.Contact_UseCase.CreateContact;
using BookManagement.Application.UseCases.Role_UseCase.CreateRole;
using BookManagement.Application.UseCases.Role_UseCase.GetRole;
using BookManagement.Application.UseCases.Role_UseCase.GetRoleById;
using BookManagement.Application.UseCases.Role_UseCase.UpdateRole;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public RoleController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateRoleUseCaseInput, CreateRoleUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetRoleUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetRoleUseCaseInput, GetRoleUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetRoleByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateRoleUseCaseInput, UpdateRoleUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
