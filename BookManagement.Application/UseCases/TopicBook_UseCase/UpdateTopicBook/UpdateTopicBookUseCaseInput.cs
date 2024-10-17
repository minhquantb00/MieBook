using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.UpdateTopicBook
{
    public class UpdateTopicBookUseCaseInput
    {
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
