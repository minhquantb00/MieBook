using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Contact_UseCase.MapperGlobal
{
    public class ContactConverter
    {
        public DataResponseContact EntityToDTO(Contact contact)
        {
            return new DataResponseContact
            {
                Address = contact.Address,
                ContactText = contact.ContactText,
                Email = contact.Email,
                Hotline = contact.Hotline,
                Id = contact.Id,
                PhoneNumber = contact.PhoneNumber,
            };
        }
    }
}
