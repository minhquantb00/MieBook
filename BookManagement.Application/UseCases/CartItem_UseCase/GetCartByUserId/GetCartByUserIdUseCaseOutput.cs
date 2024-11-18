using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Cart_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.GetCartByUserId
{
    public class GetCartByUserIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseCart DataResponseCart { get; set; }
    }
}
