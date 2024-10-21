using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.Contact_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Contact_UseCase.GetContact
{
    public class GetContactUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseContact> DataResponseContacts { get; set; }
    }
}
