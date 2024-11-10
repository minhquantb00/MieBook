using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.DeleteAddressUser
{
    public class DeleteAddressUserUseCase : IUseCase<DeleteAddressUserUseCaseInput, DeleteAddressUserUseCaseOutput>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<AddressUser> _addressUserRepository;
        private readonly IRepository<User> _userRepository;
        public DeleteAddressUserUseCase(IHttpContextAccessor contextAccessor, IRepository<AddressUser> addressUserRepository, IRepository<User> userRepository)
        {
            _contextAccessor = contextAccessor;
            _addressUserRepository = addressUserRepository;
            _userRepository = userRepository;
        }

        public async Task<DeleteAddressUserUseCaseOutput> ExcuteAsync(DeleteAddressUserUseCaseInput input)
        {
            DeleteAddressUserUseCaseOutput result = new DeleteAddressUserUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _contextAccessor.HttpContext.User;
            string userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            var addressUser = await _addressUserRepository.GetByIdAsync(input.Id);
            if(addressUser.UserId != long.Parse(userId))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            if(addressUser == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            try
            {
                await _addressUserRepository.DeleteAsync(addressUser.Id);
                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
