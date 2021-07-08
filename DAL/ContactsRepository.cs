using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;
using static System.Data.CommandType;

namespace WebApi.DAL
{
    public class ContactsRepository : BaseRepository, IContactsRepository
    {
        public List<Contacts> GetContacts(int? ContactId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ContactId", ContactId);
            var ContactsList = SqlMapper.Query<Contacts>(con, "GetContacts", param: parameters, commandType: StoredProcedure).ToList();
            return ContactsList;
        }
        public int AddContact(Contacts entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@PhoneNumber", entity.PhoneNumber);
                parameters.Add("@Status", entity.Status);
                var response = SqlMapper.ExecuteScalar(con, "AddEditContact", param: parameters, commandType: StoredProcedure);
                var resp = Convert.ToInt32(response);
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteContact(int ContactId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ContactId", ContactId);
            parameters.Add("return", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            SqlMapper.ExecuteScalar(con, "DeleteContact", param: parameters, commandType: StoredProcedure);
            return Convert.ToInt32(parameters.Get<int>("return"));
        }

        public int UpdateContact(Contacts entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ContactId", entity.ContactId);
            parameters.Add("@FirstName", entity.FirstName);
            parameters.Add("@LastName", entity.LastName);
            parameters.Add("@Email", entity.Email);
            parameters.Add("@PhoneNumber", entity.PhoneNumber);
            parameters.Add("@Status", entity.Status);
            var response = SqlMapper.ExecuteScalar(con, "AddEditContact", param: parameters, commandType: StoredProcedure);
            var resp = Convert.ToInt32(response);
            return resp;
        }
    }
}
