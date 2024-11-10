using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Contact_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Contact_UseCase.GetContact
{
    public class GetContactUseCase : IUseCase<GetContactUseCaseInput, GetContactUseCaseOutput>
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly ContactConverter _converter;
        public GetContactUseCase(IRepository<Contact> contactRepository, ContactConverter converter)
        {
            _contactRepository = contactRepository;
            _converter = converter;
        }

        public async Task<GetContactUseCaseOutput> ExcuteAsync(GetContactUseCaseInput input)
        {
            GetContactUseCaseOutput result = new GetContactUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _contactRepository.GetAllAsync();
            if(!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.AsNoTracking().Where(record => record.Hotline.Equals(input.Keyword) || record.Email.Equals(input.Keyword) || record.PhoneNumber.Equals(input.Keyword));
            }
            result.DataResponseContacts = query.AsNoTracking().Select(item => _converter.EntityToDTO(item));
            result.Succeeded = true;
            return result;
        }
    }
}
