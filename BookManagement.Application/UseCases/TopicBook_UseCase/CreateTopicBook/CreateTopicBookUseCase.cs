using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.CreateTopicBook
{
    public class CreateTopicBookUseCase : IUseCase<CreateTopicBookUseCaseInput, CreateTopicBookUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<TopicBook> _topicBookRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateTopicBookUseCase(IRepository<User> userRepository, IRepository<TopicBook> topicBookRepository,  IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
            _topicBookRepository = topicBookRepository;
        }
        public async Task<CreateTopicBookUseCaseOutput> ExcuteAsync(CreateTopicBookUseCaseInput input)
        {
            CreateTopicBookUseCaseOutput result = new CreateTopicBookUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            if (!currentUser.IsInRole("Admin"))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            try
            {
                TopicBook topicBook = new TopicBook
                {
                    Banner = "",
                    Name = input.Name,
                };
                topicBook = await _topicBookRepository.CreateAsync(topicBook);
                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
