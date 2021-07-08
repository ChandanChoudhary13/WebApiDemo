using WebApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Services
{
    public interface IContactService
    {
        GlobalResponseModel<List<Contacts>> GetContacts(int? ContactId);
        GlobalResponseModel<bool> AddContact(Contacts contact);
        GlobalResponseModel<bool> UpdateContact(Contacts contact);
        GlobalResponseModel<bool> DeleteContact(int ContactId);
    }
}
