using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.GetAddressUserById
{
    public class GetAddressUserByIdUseCase : IUseCaseGetById<long, GetAddressUserByIdUseCaseOutput>
    {
        private readonly IRepository<AddressUser> _addressUserRepository;
        private readonly AddressUserConverter _addressUserConverter;
        public GetAddressUserByIdUseCase(IRepository<AddressUser> addressUserRepository, AddressUserConverter addressUserConverter)
        {
            _addressUserRepository = addressUserRepository;
            _addressUserConverter = addressUserConverter;
        }

        public async Task<GetAddressUserByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetAddressUserByIdUseCaseOutput result = new GetAddressUserByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _addressUserRepository.GetByIdAsync(id);
            if (query != null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.DataResponseAddressUser = _addressUserConverter.EntityToDTO(query);
            result.Succeeded = true;
            return result;
        }
    }
}
