using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.ChangePassword
{
    public class ChangePasswordUseCaseInput
    {
        [Required(ErrorMessage = "Old Password is required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }
    }
}
