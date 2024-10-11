using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.User_UseCase.Register;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public UserController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
