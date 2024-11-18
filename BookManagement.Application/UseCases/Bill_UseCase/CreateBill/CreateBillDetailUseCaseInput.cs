using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Bill_UseCase.CreateBill
{
    public class CreateBillDetailUseCaseInput
    {
        public long BookId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Note { get; set; }
    }
}
