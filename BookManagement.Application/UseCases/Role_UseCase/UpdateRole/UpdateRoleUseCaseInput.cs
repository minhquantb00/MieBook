using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Role_UseCase.UpdateRole
{
    public class UpdateRoleUseCaseInput
    {
        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
