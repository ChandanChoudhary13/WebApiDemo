using WebApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Services
{
    public class ContactServices : IContactService
    {
        private IContactsRepository _IContactsRepository;
        public ContactServices(IContactsRepository IContactsRepository)
        {
            _IContactsRepository = IContactsRepository;
        }
        public GlobalResponseModel<List<Contacts>> GetContacts(int? ContactId)
        {
            GlobalResponseModel<List<Contacts>> response = new GlobalResponseModel<List<Contacts>>();
            try
            {
                var result = _IContactsRepository.GetContacts(ContactId);
                response.Data = result;
                response.IsSuccess = true;
                response.Message = string.Empty;
                response.TotalRecord = result.Count;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public GlobalResponseModel<bool> AddContact(Contacts contact)
        {
            GlobalResponseModel<bool> response = new GlobalResponseModel<bool>();
            try
            {
                int result = _IContactsRepository.AddContact(contact);
                response.Data = result > 0;
                response.IsSuccess = result > 0;
                response.Message = result > 0 ? "Save successfully !!" : "Failed to Save record !!";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public GlobalResponseModel<bool> UpdateContact(Contacts contact)
        {
            GlobalResponseModel<bool> response = new GlobalResponseModel<bool>();
            try
            {
                int result = _IContactsRepository.UpdateContact(contact);
                response.Data = result > 0;
                response.IsSuccess = result > 0;
                response.Message = result > 0 ? "Update successfully !!" : "Failed to Update record !!";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public GlobalResponseModel<bool> DeleteContact(int contactId)
        {
            GlobalResponseModel<bool> response = new GlobalResponseModel<bool>();
            try
            {
                if (contactId > 0)
                {
                    int result = _IContactsRepository.DeleteContact(contactId);
                    response.Data = result > 0;
                    response.IsSuccess = result > 0;
                    response.Message = result > 0 ? "Contact deleted successfully." : "Contact delete failure";
                }
                else
                {
                    response.IsSuccess = response.Data = false;
                    response.Message = "Invalid request";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
