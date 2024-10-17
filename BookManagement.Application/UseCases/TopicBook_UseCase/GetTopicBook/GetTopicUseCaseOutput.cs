using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.TopicBook_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBook
{
    public class GetTopicUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseTopicBook> DataResponseTopicBooks { get; set; }
    }
}
