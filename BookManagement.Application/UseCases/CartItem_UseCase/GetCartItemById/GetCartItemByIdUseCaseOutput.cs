using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.CartItem_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.GetCartItemById
{
    public class GetCartItemByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseCartItem DataResponseCartItem { get; set; }
    }
}
