using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Bill_UseCase.CreateBill;
using BookManagement.Application.UseCases.VNPay_UseCase.CreateUrlPayment;
using BookManagement.Application.UseCases.VNPay_UseCase.VNPayReturn;
using BookManagement.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public VnPayController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateVnPayUrl([FromBody] CreateUrlPaymentUseCaseInput request)
        {
            var useCase = _serviceProvider.GetService<IUseCasePayment<CreateUrlPaymentUseCaseInput, CreateUrlPaymentUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(request, HttpContext);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> VNPayReturn()
        {
            var vnpayData = HttpContext.Request.Query;
            var useCase = _serviceProvider.GetService<IUseCase<VnPayReturnUseCaseInput, VnPayReturnUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(new VnPayReturnUseCaseInput { vnpayData = vnpayData});
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
