using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.UpdateAddressUser
{
    public class UpdateAddressUserUseCase : IUseCase<UpdateAddressUserUseCaseInput, UpdateAddressUserUseCaseOutput>
    {
        private readonly IRepository<AddressUser> _repository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<User> _userRepository;
        public UpdateAddressUserUseCase(IRepository<AddressUser> repository, IHttpContextAccessor contextAccessor, IRepository<User> userRepository)
        {
            _repository = repository;
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public async Task<UpdateAddressUserUseCaseOutput> ExcuteAsync(UpdateAddressUserUseCaseInput input)
        {
            UpdateAddressUserUseCaseOutput result = new UpdateAddressUserUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            string userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            var addressUser = await _repository.GetByIdAsync(input.Id);
            if(addressUser == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            if(addressUser.UserId != long.Parse(userId))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            addressUser.Address = !string.IsNullOrEmpty(input.Address) ?   input.Address : addressUser.Address;
            addressUser = await _repository.UpdateAsync(addressUser);
            result.Succeeded = true;
            return result;

        }
    }
}
