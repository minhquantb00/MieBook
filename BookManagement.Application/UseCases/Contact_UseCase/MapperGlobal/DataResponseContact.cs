using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Contact_UseCase.MapperGlobal
{
    public class DataResponseContact
    {
        public long Id { get; set; }
        public string Hotline { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactText { get; set; }
    }
}
