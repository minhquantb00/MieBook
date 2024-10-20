using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.TopicBook_UseCase.CreateTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.DeleteTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBook;
using BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBookById;
using BookManagement.Application.UseCases.TopicBook_UseCase.UpdateTopicBook;
using BookManagement.Application.UseCases.Voucher_UseCase.CreateVoucher;
using BookManagement.Application.UseCases.Voucher_UseCase.DeleteVoucher;
using BookManagement.Application.UseCases.Voucher_UseCase.GetVoucher;
using BookManagement.Application.UseCases.Voucher_UseCase.GetVoucherById;
using BookManagement.Application.UseCases.Voucher_UseCase.UpdateVoucher;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public VoucherController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteVoucher([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCase<DeleteVoucherUseCaseInput, DeleteVoucherUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new DeleteVoucherUseCaseInput { Id = id });
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateVoucher([FromBody] CreateVoucherUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateVoucherUseCaseInput, CreateVoucherUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateVoucher([FromBody] UpdateVoucherUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateVoucherUseCaseInput, UpdateVoucherUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVouchers([FromQuery] GetVoucherUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetVoucherUseCaseInput, GetVoucherUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoucherById([FromRoute] long id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<long, GetVoucherByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
