using WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Entities;

namespace WebAPI.Controllers
{
    public class ContactsController : ApiController
    {
        private IContactService _IContactService;
        public ContactsController(IContactService IContactService)
        {
            _IContactService = IContactService;
        }

        /// <summary>
        /// To Get Contacts List or When Pass ContactId get Accordingly record
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetContacts(int? contactId)
        {
            try
            {
                var data = _IContactService.GetContacts(contactId);
                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// To Save Contacts - Add Purpose Only
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddContacts(Contacts contacts)
        {
            try
            {
                var response = _IContactService.AddContact(contacts);
                return Request.CreateResponse(HttpStatusCode.OK, response, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// To Save Contacts - Update Purpose Only
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateContact(Contacts contacts)
        {
            try
            {
                var response = _IContactService.UpdateContact(contacts);
                return Request.CreateResponse(HttpStatusCode.OK, response, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// To Delete Contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteContact(int contactId)
        {
            try
            {
                var response = _IContactService.DeleteContact(contactId);
                return Request.CreateResponse(HttpStatusCode.OK, response, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
