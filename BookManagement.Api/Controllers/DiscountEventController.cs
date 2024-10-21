using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Category_UseCase.CreateCategory;
using BookManagement.Application.UseCases.Category_UseCase.DeleteCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategoryById;
using BookManagement.Application.UseCases.Category_UseCase.UpdateCategory;
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
    public class DiscountEventController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public DiscountEventController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteDiscountEvent([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteDiscountEventUseCaseInput, DeleteDiscountEventUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteDiscountEventUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateDiscountEvent([FromForm] CreateDiscountEventUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateDiscountEventUseCaseInput, CreateDiscountEventUseCaseOutput>>();
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
        public async Task<IActionResult> UpdateDiscountEvent([FromForm] UpdateDiscountEventUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateDiscountEventUseCaseInput, UpdateDiscountEventUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> GetAllCategories([FromForm] GetDiscountEventUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetDiscountEventUseCaseInput, GetDiscountEventUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountEventById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetDiscountEventByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
