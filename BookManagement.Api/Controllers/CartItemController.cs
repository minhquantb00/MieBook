using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.BookReview_UseCase.CreateBookReview;
using BookManagement.Application.UseCases.BookReview_UseCase.DeleteBookReview;
using BookManagement.Application.UseCases.BookReview_UseCase.GetBookReviewById;
using BookManagement.Application.UseCases.CartItem_UseCase.CreateCartItem;
using BookManagement.Application.UseCases.CartItem_UseCase.DeleteCartItem;
using BookManagement.Application.UseCases.CartItem_UseCase.GetCartItemById;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public CartItemController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItem([FromBody] CreateCartItemUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateCartItemUseCaseInput, CreateCartItemUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCartItem([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteCartItemUseCaseInput, DeleteCartItemUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteCartItemUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetCartItemByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
