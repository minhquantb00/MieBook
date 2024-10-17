using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.User_UseCase.ChangePassword;
using BookManagement.Application.UseCases.User_UseCase.ConfirmCreateNewPassword;
using BookManagement.Application.UseCases.User_UseCase.ForgotPassword;
using BookManagement.Application.UseCases.User_UseCase.GetUser;
using BookManagement.Application.UseCases.User_UseCase.GetUserById;
using BookManagement.Application.UseCases.User_UseCase.Login;
using BookManagement.Application.UseCases.User_UseCase.Register;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<LoginUserUseCaseInput, LoginUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<ChangePasswordUseCaseInput, ChangePasswordUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<ForgotPasswordUseCaseInput, ForgotPasswordUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmCreateNewPassword([FromBody] ConfirmCreateNewPasswordUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<ConfirmCreateNewPasswordUseCaseInput, ConfirmCreateNewPasswordUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUserUseCaseInput? input)
        {
            var userCase = _serviceProvider.GetService<IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>>();
            var result = await userCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] long id)
        {
            var userCase = _serviceProvider.GetService<IUseCaseGetById<long, GetUserByIdUseCaseOutput>>();
            var result = await userCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
