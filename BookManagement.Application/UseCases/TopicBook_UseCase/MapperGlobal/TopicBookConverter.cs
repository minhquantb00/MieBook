using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.MapperGlobal
{
    public class TopicBookConverter
    {
        public DataResponseTopicBook EntityToDTO(TopicBook topicBook)
        {
            return new DataResponseTopicBook
            {
                Id = topicBook.Id,
                Banner = topicBook.Banner,
                Name = topicBook.Name,
            };
        }
    }
}
