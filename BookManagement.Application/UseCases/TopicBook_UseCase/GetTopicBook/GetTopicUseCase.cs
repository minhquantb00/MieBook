using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.TopicBook_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBook
{
    public class GetTopicUseCase : IUseCase<GetTopicUseCaseInput, GetTopicUseCaseOutput>
    {
        private readonly IRepository<TopicBook> _topicBookRepository;
        private readonly TopicBookConverter _topicBookConverter;
        public GetTopicUseCase(IRepository<TopicBook> topicBookRepository, TopicBookConverter topicBookConverter)
        {
            _topicBookConverter = topicBookConverter;
            _topicBookRepository = topicBookRepository;
        }
        public async Task<GetTopicUseCaseOutput> ExcuteAsync(GetTopicUseCaseInput input)
        {
            GetTopicUseCaseOutput result = new GetTopicUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _topicBookRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.AsNoTracking().Where(record => record.Name.Contains(input.Name));
            }

            result.Succeeded = true;
            result.DataResponseTopicBooks = query.AsNoTracking().Select(item => _topicBookConverter.EntityToDTO(item));
            return result;
        }

        public Task<GetTopicUseCaseOutput> ExcuteAsync(long? id, GetTopicUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
