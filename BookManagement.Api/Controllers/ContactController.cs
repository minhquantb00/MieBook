using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Category_UseCase.CreateCategory;
using BookManagement.Application.UseCases.Category_UseCase.DeleteCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategoryById;
using BookManagement.Application.UseCases.Category_UseCase.UpdateCategory;
using BookManagement.Application.UseCases.Contact_UseCase.CreateContact;
using BookManagement.Application.UseCases.Contact_UseCase.DeleteContact;
using BookManagement.Application.UseCases.Contact_UseCase.GetContact;
using BookManagement.Application.UseCases.Contact_UseCase.GetContactById;
using BookManagement.Application.UseCases.Contact_UseCase.UpdateContact;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public ContactController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteContact([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteContactUseCaseInput, DeleteContactUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteContactUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateContactUseCaseInput, CreateContactUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateContactUseCaseInput, UpdateContactUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts([FromQuery] GetContactUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetContactUseCaseInput, GetContactUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetContactByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
