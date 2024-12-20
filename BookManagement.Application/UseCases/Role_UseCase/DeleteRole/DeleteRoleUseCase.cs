﻿using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Role_UseCase.DeleteRole
{
    public class DeleteRoleUseCase : IUseCase<DeleteRoleUseCaseInput, DeleteRoleUseCaseOutput>
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteRoleUseCase(IRepository<Role> roleRepository, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _roleRepository = roleRepository;
        }
        public async Task<DeleteRoleUseCaseOutput> ExcuteAsync(DeleteRoleUseCaseInput input)
        {
            DeleteRoleUseCaseOutput result = new DeleteRoleUseCaseOutput
            {
                Succeeded = false
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
                var role = await _roleRepository.GetByIdAsync(input.Id);
                if (role == null)
                {
                    result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                    return result;
                }
                await _roleRepository.DeleteAsync(role.Id);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
