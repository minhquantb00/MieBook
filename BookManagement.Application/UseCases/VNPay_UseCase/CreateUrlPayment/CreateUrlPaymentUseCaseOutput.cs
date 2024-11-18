using BookManagement.Application.OuputBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.VNPay_UseCase.CreateUrlPayment
{
    public class CreateUrlPaymentUseCaseOutput : UseCaseOutputBase
    {
        public string URL { get; set; }
    }
}
