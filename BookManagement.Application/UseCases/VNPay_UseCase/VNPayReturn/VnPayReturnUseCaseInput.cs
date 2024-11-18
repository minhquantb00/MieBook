using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.VNPay_UseCase.VNPayReturn
{
    public class VnPayReturnUseCaseInput
    {
        public IQueryCollection vnpayData {  get; set; }
    }
}
