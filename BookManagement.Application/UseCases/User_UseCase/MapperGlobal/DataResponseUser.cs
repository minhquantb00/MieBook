using BookManagement.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.MapperGlobal
{
    public class DataResponseUser
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string PinCode { get; set; }
        public string AddressDefaultName { get; set; }
        public int Point { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
