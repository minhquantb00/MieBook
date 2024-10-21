using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.Role_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Role_UseCase.GetRoleById
{
    public class GetRoleByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseRole DataResponseRole    { get; set; }
    }
}
