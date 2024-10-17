using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.TopicBook_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBookById
{
    public class GetTopicBookByIdUseCase : IUseCaseGetById<long, GetTopicBookByIdUseCaseOutput>
    {
        private readonly IRepository<TopicBook> _topicBookRepository;
        private readonly TopicBookConverter _topicBookConverter;
        public GetTopicBookByIdUseCase(IRepository<TopicBook> topicBookRepository,
            TopicBookConverter topicBookConverter)
        {
            _topicBookRepository = topicBookRepository;
            _topicBookConverter = topicBookConverter;
        }
        public async Task<GetTopicBookByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetTopicBookByIdUseCaseOutput result = new GetTopicBookByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _topicBookRepository.GetByIdAsync(id);
            if(query == null)
            {
                result.Errors = new string[] { "Chủ đề không tồn tại" };
                return result;
            }
            result.Succeeded = true;
            result.DataResponseTopicBook = _topicBookConverter.EntityToDTO(query);
            return result;
        }
    }
}
