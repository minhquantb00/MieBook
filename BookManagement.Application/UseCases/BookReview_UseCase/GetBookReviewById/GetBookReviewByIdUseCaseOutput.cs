using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.BookReview_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.BookReview_UseCase.GetBookReviewById
{
    public class GetBookReviewByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseBookReview DataResponseBookReview { get; set; }
    }
}
