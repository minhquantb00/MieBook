using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.MapperGlobal
{
    public class UserConverter
    {
        private readonly IRepository<AddressUser> _addressUserRepository;
        public UserConverter(IRepository<AddressUser> addressUserRepository)
        {
            _addressUserRepository = addressUserRepository;
        }

        public DataResponseUser EntityToDTO(User user)
        {
            return new DataResponseUser
            {
                AddressDefaultName = user.AddressDefaultId != 0 && user.AddressDefaultId.HasValue ? _addressUserRepository.GetAsync(item => item.Id == user.AddressDefaultId).Result.Address : "",
                CreateTime =  user.CreateTime,
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender == Commons.Enums.Enumerate.Gender.Nam ? "Nam" : "Nữ",
                Id = user.Id,
                NickName = user.NickName,
                PhoneNumber = user.PhoneNumber,
                PinCode = user.PinCode,
                Point = user.Point,
            };
        }
    }
}
