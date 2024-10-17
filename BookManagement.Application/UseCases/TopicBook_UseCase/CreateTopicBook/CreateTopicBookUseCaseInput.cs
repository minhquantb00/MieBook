using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.TopicBook_UseCase.CreateTopicBook
{
    public class CreateTopicBookUseCaseInput
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
