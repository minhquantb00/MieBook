using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.CreateBook;
using BookManagement.Application.UseCases.Book_UseCase.DeleteBook;
using BookManagement.Application.UseCases.BookReview_UseCase.CreateBookReview;
using BookManagement.Application.UseCases.BookReview_UseCase.DeleteBookReview;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public BookReviewController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateBookReview([FromForm] CreateBookReviewUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateBookReviewUseCaseInput, CreateBookReviewUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteBookReview([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteBookReviewUseCaseInput, DeleteBookReviewUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteBookReviewUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
