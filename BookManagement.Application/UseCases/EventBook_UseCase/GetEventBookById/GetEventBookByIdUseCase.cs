using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.EventBook_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Role_UseCase.GetRoleById;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.GetEventBookById
{
    public class GetEventBookByIdUseCase : IUseCaseGetById<long, GetEventBookByIdUseCaseOutput>
    {
        private readonly IRepository<EventBook> _eventBookRepository;
        private readonly EventBookConverter _eventBookConverter;
        public GetEventBookByIdUseCase(IRepository<EventBook> eventBookRepository, EventBookConverter eventBookConverter)
        {
            _eventBookConverter = eventBookConverter;
            _eventBookRepository = eventBookRepository;
        }
        public async Task<GetEventBookByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetEventBookByIdUseCaseOutput result = new GetEventBookByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _eventBookRepository.GetByIdAsync(id);
            if (query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.Succeeded = true;
            result.DataResponseEventBook = _eventBookConverter.EntityToDTO(query);
            return result;
        }
    }
}
