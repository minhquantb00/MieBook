using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.EventBook_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Role_UseCase.GetRole;
using BookManagement.Application.UseCases.Role_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.GetEventBook
{
    public class GetEventBookUseCase : IUseCase<GetEventBookUseCaseInput, GetEventBookUseCaseOutput>
    {
        private readonly IRepository<EventBook> _eventBookRepository;
        private readonly EventBookConverter _eventBookConverter;
        public GetEventBookUseCase(IRepository<EventBook> eventBookRepository, EventBookConverter eventBookConverter)
        {
            _eventBookConverter = eventBookConverter;
            _eventBookRepository = eventBookRepository;
        }
        public async Task<GetEventBookUseCaseOutput> ExcuteAsync(GetEventBookUseCaseInput input)
        {
            GetEventBookUseCaseOutput result = new GetEventBookUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _eventBookRepository.GetAllAsync();
            if (input.DiscountEventId.HasValue)
            {
                query = query.AsNoTracking().Where(record => record.DiscountEventId == input.DiscountEventId);
            }
            result.DataResponseEventBooks = query.AsNoTracking().Select(item => _eventBookConverter.EntityToDTO(item));
            result.Succeeded = true;
            return result;
        }

        public Task<GetEventBookUseCaseOutput> ExcuteAsync(long? id, GetEventBookUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
