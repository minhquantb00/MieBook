using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Role_UseCase.CreateRole
{
    public class CreateRoleUseCase : IUseCase<CreateRoleUseCaseInput, CreateRoleUseCaseOutput>
    {
        private readonly IRepository<Role> _repository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateRoleUseCase(IRepository<Role> repository, IHttpContextAccessor contextAccessor)
        {
            _repository = repository;
            _contextAccessor = contextAccessor;
        }

        public async Task<CreateRoleUseCaseOutput> ExcuteAsync(CreateRoleUseCaseInput input)
        {
            CreateRoleUseCaseOutput result = new CreateRoleUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            if (!currentUser.IsInRole("Admin"))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            try
            {
                Role role = new Role
                {
                    Code = input.Code,
                    Name = input.Name,
                };
                role = await _repository.CreateAsync(role);
                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<CreateRoleUseCaseOutput> ExcuteAsync(long? id, CreateRoleUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
