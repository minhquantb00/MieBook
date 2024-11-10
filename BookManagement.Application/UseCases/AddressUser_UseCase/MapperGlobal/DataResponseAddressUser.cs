using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal
{
    public class DataResponseAddressUser
    {
        public long Id { get; set; }
        public DataResponseUser DataResponseUser { get; set; }
        public string Address { get; set; }
    }
}
