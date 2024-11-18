using BookManagement.Commons.Enums;
using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Bill_UseCase.CreateBill
{
    public class CreateBillUseCaseInput
    {
        public long ShippingMethodId { get; set; }
        public long AddressUserId { get; set; }
        public long PaymentMethodId { get; set; }
        public string? Note { get; set; }
        public long? UserVoucherId { get; set; }
        public List<CreateBillDetailUseCaseInput> CreateBillDetailUseCaseInputs { get; set; }
    }
}
