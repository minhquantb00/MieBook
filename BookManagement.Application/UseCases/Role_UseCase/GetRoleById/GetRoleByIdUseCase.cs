using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Role_UseCase.GetRoleById
{
    public class GetRoleByIdUseCase : IUseCaseGetById<long, GetRoleByIdUseCaseOutput>
    {
        private readonly IRepository<Role> _repository;
        private readonly RoleConverter _converter;
        public GetRoleByIdUseCase(IRepository<Role> repository, RoleConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public async Task<GetRoleByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetRoleByIdUseCaseOutput result = new GetRoleByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _repository.GetByIdAsync(id);
            if(query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.Succeeded = true;
            result.DataResponseRole = _converter.EntityToDTO(query);
            return result;
        }
    }
}
