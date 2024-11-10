using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.UpdateTopicBook
{
    public class UpdateTopicBookUseCase : IUseCase<UpdateTopicBookUseCaseInput, UpdateTopicBookUseCaseOutput>
    {
        private readonly IRepository<TopicBook> _topicBookRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateTopicBookUseCase(IRepository<TopicBook> topicBookRepository, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _topicBookRepository = topicBookRepository;
        }
        public async Task<UpdateTopicBookUseCaseOutput> ExcuteAsync(UpdateTopicBookUseCaseInput input)
        {
            UpdateTopicBookUseCaseOutput result = new UpdateTopicBookUseCaseOutput
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
                var topicBook = await _topicBookRepository.GetByIdAsync(input.Id);
                if (topicBook == null)
                {
                    result.Errors = new string[] { "Chủ đề không tồn tại" };
                    return result;
                }
                topicBook.Name = !string.IsNullOrEmpty(input.Name) ? input.Name : topicBook.Name;
                topicBook = await _topicBookRepository.UpdateAsync(topicBook);

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
