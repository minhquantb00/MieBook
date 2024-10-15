using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.ConfirmCreateNewPassword
{
    public class ConfirmCreateNewPasswordUseCaseInput
    {
        [Required(ErrorMessage = "Confirm code is required")]
        public string ConfirmCode { get; set; }
        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm new password is required")]
        public string ConfirmNewPassword { get; set; }
    }
}
