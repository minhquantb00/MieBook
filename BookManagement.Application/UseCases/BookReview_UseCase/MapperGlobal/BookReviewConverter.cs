using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.BookReview_UseCase.MapperGlobal
{
    public class BookReviewConverter
    {
        private readonly IRepository<User> _userRepository;
        public BookReviewConverter(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public DataResponseBookReview EntityToDTO(BookReview entity)
        {
            return new DataResponseBookReview
            {
                Id = entity.Id,
                ReviewTime = entity.ReviewTime,
                Content = entity.Content,
                FullName = _userRepository.GetByIdAsync(entity.UserId).Result.FullName,
                ImageUrl = entity.ImageUrl,
                NumberOfStars = entity.NumberOfStars,
            };
        }
    }
}
