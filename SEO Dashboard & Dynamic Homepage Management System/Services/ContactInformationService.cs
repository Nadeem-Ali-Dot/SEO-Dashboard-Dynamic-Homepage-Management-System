using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class ContactInformationService : IContactInformation
    {
        private readonly ApplicationDbContext _dbContext;
        public ContactInformationService(ApplicationDbContext applicationDb)
        {
            _dbContext = applicationDb;
        }
        public async Task<APIResponse> Add(ContactInformation obj)
        { 
            if(obj.Id != 0)
            {
                var data = _dbContext.contactInformation.FindAsync(obj.Id);

            }
            else
            {
                _dbContext.contactInformation.AddAsync(obj);
                _dbContext.SaveChanges();

            }

        
            return new APIResponse
            {
                IsSuccess = true,
                Result = obj,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Delete(int id)
        {
            var data = await _dbContext.contactInformation.FindAsync(id);
            if (data != null)
            {
                _dbContext.contactInformation.Remove(data);
                _dbContext.SaveChanges();
                return new APIResponse
                {
                    IsSuccess = true,
                    Result = data,
                    statusCode = System.Net.HttpStatusCode.OK
                };
            }
            else
            {
                return new APIResponse
                {
                    IsSuccess = true,
                    Result = data,
                    statusCode = System.Net.HttpStatusCode.NotFound
                };
            }



        }

        public async Task<APIResponse> GetAll()
        {
            var data = await _dbContext.contactInformation.ToListAsync();

            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> GetSingle(int id)
        {
            var data = await _dbContext.contactInformation.FindAsync(id);
            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Update(int Id, ContactInformation obj)
        {
            var data = await _dbContext.contactInformation.FindAsync(Id);
            if (data != null)
            {
                data.PhoneNumber = obj.PhoneNumber;
                data.Email = obj.Email;
                data.OfficeAddress = obj.OfficeAddress;
               

                _dbContext.SaveChanges();

                return new APIResponse { IsSuccess = true, Result = data, statusCode = System.Net.HttpStatusCode.OK };
            }
            else
            {
                return new APIResponse { IsSuccess = true, Result = null, statusCode = System.Net.HttpStatusCode.NotFound };
            }
        }
    }
}
