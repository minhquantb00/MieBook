using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.Cart_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Cart_UseCase.GetCartById
{
    public class GetCartByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseCart DataResponseCart { get; set; }
    }
}
