using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal
{
    public class AddressUserConverter
    {
        private readonly IRepository<User> _repsitory;
        private readonly UserConverter _converter;
        public AddressUserConverter(IRepository<User> repsitory, UserConverter converter)
        {
            _repsitory = repsitory;
            _converter = converter;
        }
        public DataResponseAddressUser EntityToDTO(AddressUser addressUser)
        {
            return new DataResponseAddressUser
            {
                Id = addressUser.Id,    
                Address = addressUser.Address,
                DataResponseUser = _converter.EntityToDTO(_repsitory.GetByIdAsync(addressUser.UserId).Result)
            };
        }
    }
}
