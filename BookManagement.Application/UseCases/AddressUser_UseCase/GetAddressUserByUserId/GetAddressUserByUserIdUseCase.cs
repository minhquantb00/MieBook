using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.CartItem_UseCase.GetCartByUserId;
using BookManagement.Application.UseCases.CartItem_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.GetAddressUserByUserId
{
    public class GetAddressUserByUserIdUseCase : IUseCaseGetById<long, GetAddressUserByUserIdUseCaseOutput>
    {
        private readonly IRepository<AddressUser> _addressUserRepository;
        private readonly IRepository<User> _userRepository;
        private readonly AddressUserConverter _addressUserConverter;
        private readonly UserConverter _userConverter;
        public GetAddressUserByUserIdUseCase(IRepository<AddressUser> addressUserRepository, IRepository<User> userRepository, AddressUserConverter addressUserConverter, UserConverter userConverter)
        {
            _userRepository = userRepository;
            _addressUserConverter = addressUserConverter;
            _addressUserRepository = addressUserRepository;
            _userConverter = userConverter;
        }
        public async Task<GetAddressUserByUserIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetAddressUserByUserIdUseCaseOutput result = new GetAddressUserByUserIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _addressUserRepository.GetAllAsync(x => x.UserId == id);
            if (query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.DataResponseAddressUser = query.AsNoTracking().ToList().Select(item => new DataResponseAddressUser
            {
                Address = _addressUserRepository.GetAsync(address => address.Id == item.Id).Result.Address,
                DataResponseUser = _userConverter.EntityToDTO(_userRepository.GetByIdAsync(id).Result),
                Id = item.Id,
            }).AsQueryable();
            result.Succeeded = true;
            return result;
        }
    }
}
