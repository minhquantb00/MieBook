﻿using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.DeleteTopicBook
{
    public class DeleteTopicBookUseCase : IUseCase<DeleteTopicBookUseCaseInput, DeleteTopicBookUseCaseOutput>
    {
        private readonly IRepository<TopicBook> _topicBookRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteTopicBookUseCase(IRepository<TopicBook> topicBookRepository, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _topicBookRepository = topicBookRepository;
        }
        public async Task<DeleteTopicBookUseCaseOutput> ExcuteAsync(DeleteTopicBookUseCaseInput input)
        {
            DeleteTopicBookUseCaseOutput result = new DeleteTopicBookUseCaseOutput
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

                await _topicBookRepository.DeleteAsync(topicBook.Id);

                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] {ex.Message};
                return result;
            }
        }

        public Task<DeleteTopicBookUseCaseOutput> ExcuteAsync(long? id, DeleteTopicBookUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
