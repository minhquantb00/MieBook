using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.GetAddressUser
{
    public class GetAddressUserUseCase : IUseCase<GetAddressUserUseCaseInput, GetAddressUserUseCaseOutput>
    {
        private readonly AddressUserConverter _addressUserConverter;
        private readonly IRepository<AddressUser> _repository;
        public GetAddressUserUseCase(AddressUserConverter addressUserConverter, IRepository<AddressUser> repository)
        {
            _addressUserConverter = addressUserConverter;
            _repository = repository;
        }

        public async Task<GetAddressUserUseCaseOutput> ExcuteAsync(GetAddressUserUseCaseInput input)
        {
            GetAddressUserUseCaseOutput result = new GetAddressUserUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _repository.GetAllAsync(x => x.UserId == input.UserId);
            result.DataResponseAddressUsers = query.AsNoTracking().Select(item => _addressUserConverter.EntityToDTO(item));
            return result;
        }
    }
}
