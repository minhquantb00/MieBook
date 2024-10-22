using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.EventBook_UseCase.CreateEventBook;
using BookManagement.Application.UseCases.EventBook_UseCase.DeleteEventBook;
using BookManagement.Application.UseCases.EventBook_UseCase.GetEventBook;
using BookManagement.Application.UseCases.EventBook_UseCase.GetEventBookById;
using BookManagement.Application.UseCases.EventBook_UseCase.UpdateEventBook;
using BookManagement.Application.UseCases.Role_UseCase.CreateRole;
using BookManagement.Application.UseCases.Role_UseCase.DeleteRole;
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
    public class EventBookController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public EventBookController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateEventBook([FromBody] CreateEventBookUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateEventBookUseCaseInput, CreateEventBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventBooks([FromQuery] GetEventBookUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetEventBookUseCaseInput, GetEventBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventBookById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetEventBookByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateEventBook([FromBody] UpdateEventBookUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateEventBookUseCaseInput, UpdateEventBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteEventBook([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteEventBookUseCaseInput, DeleteEventBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteEventBookUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
