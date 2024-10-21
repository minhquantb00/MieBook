using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Role_UseCase.MapperGlobal
{
    public class RoleConverter
    {
        public DataResponseRole EntityToDTO(Role role)
        {
            return new DataResponseRole
            {
                Code = role.Code,
                Id = role.Id,
                Name = role.Name,
            };
        }
    }
}
