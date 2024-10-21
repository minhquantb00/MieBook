using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Contact_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Contact_UseCase.GetContactById
{
    public class GetContactByIdUseCase : IUseCaseGetById<long, GetContactByIdUseCaseOutput>
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly ContactConverter _converter;
        public GetContactByIdUseCase(IRepository<Contact> contactRepository, ContactConverter converter)
        {
            _contactRepository = contactRepository;
            _converter = converter;
        }

        public async Task<GetContactByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetContactByIdUseCaseOutput result = new GetContactByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _contactRepository.GetByIdAsync(id);
            if(query == null)
            {
                result.Errors = new string[] { "Không tìm thấy liên hệ" };
                return result;
            }
            result.Succeeded = true;
            result.DataResponseContact = _converter.EntityToDTO(query);
            return result;
        }
    }
}
