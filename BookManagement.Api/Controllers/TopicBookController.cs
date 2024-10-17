using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Category_UseCase.CreateCategory;
using BookManagement.Application.UseCases.Category_UseCase.DeleteCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategory;
using BookManagement.Application.UseCases.Category_UseCase.GetCategoryById;
using BookManagement.Application.UseCases.Category_UseCase.UpdateCategory;
using BookManagement.Application.UseCases.TopicBook_UseCase.CreateTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.DeleteTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBookById;
using BookManagement.Application.UseCases.TopicBook_UseCase.UpdateTopicBook;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class TopicBookController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public TopicBookController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteTopicBook([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteTopicBookUseCaseInput, DeleteTopicBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteTopicBookUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateTopicBook([FromBody] CreateTopicBookUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateTopicBookUseCaseInput, CreateTopicBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateTopicBook([FromBody] UpdateTopicBookUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateTopicBookUseCaseInput, UpdateTopicBookUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetTopicUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetTopicUseCaseInput, GetTopicUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicBookById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetTopicBookByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
