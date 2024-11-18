using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.BookReview_UseCase.CreateBookReview;
using BookManagement.Application.UseCases.BookReview_UseCase.GetBookReviewById;
using BookManagement.Application.UseCases.Cart_UseCase.CreateCart;
using BookManagement.Application.UseCases.Cart_UseCase.GetCartById;
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
    public class CartController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public CartController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateCartUseCaseInput, CreateCartUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetCartByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartByUserId([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetCartByUserIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
