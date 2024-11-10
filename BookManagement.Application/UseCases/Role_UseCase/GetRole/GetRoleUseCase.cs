using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Role_UseCase.GetRole
{
    public class GetRoleUseCase : IUseCase<GetRoleUseCaseInput, GetRoleUseCaseOutput>
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly RoleConverter _roleConverter;
        public GetRoleUseCase(IRepository<Role> roleRepository, RoleConverter roleConverter)
        {
            _roleRepository = roleRepository;
            _roleConverter = roleConverter;
        }

        public async Task<GetRoleUseCaseOutput> ExcuteAsync(GetRoleUseCaseInput input)
        {
            GetRoleUseCaseOutput result = new GetRoleUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _roleRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.AsNoTracking().Where(record => record.Name.Contains(input.Keyword) || record.Code.Contains(input.Keyword));
            }
            result.DataResponseRoles = query.AsNoTracking().Select(item => _roleConverter.EntityToDTO(item));
            result.Succeeded = true;
            return result;
        }
    }
}
