using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.DAL
{
    public interface IContactsRepository
    {
        List<Contacts> GetContacts(int? ContactId);
        int AddContact(Contacts contact);
        int UpdateContact(Contacts contact);
        int DeleteContact(int ContactId);
    }
}
