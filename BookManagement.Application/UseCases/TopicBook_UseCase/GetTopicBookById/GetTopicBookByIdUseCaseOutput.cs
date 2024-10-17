using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.TopicBook_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.GetTopicBookById
{
    public class GetTopicBookByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseTopicBook DataResponseTopicBook { get; set; }
    }
}
