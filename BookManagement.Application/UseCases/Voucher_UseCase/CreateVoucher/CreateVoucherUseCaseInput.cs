using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.CreateVoucher
{
    public class CreateVoucherUseCaseInput
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "DiscountPercent is required")]
        public double DiscountPercent { get; set; }
    }
}
