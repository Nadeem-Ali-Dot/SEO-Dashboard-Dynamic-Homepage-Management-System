using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class OccasionsService : IOccasions
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICloudinaryService _cloudinaryService;
        public OccasionsService(ApplicationDbContext applicationDb, ICloudinaryService cloudinaryService)
        {
            _dbContext = applicationDb;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<APIResponse> Add(OccasionsRequestModel obj)
        {
            var Occasions = new Occasions();

            if (obj.Id != 0)
            {
                var Occas = await _dbContext.occasions.FindAsync(obj.Id);
                if (obj.ImageUrl != null)
                {
                    await _cloudinaryService.DeleteImageAsync(obj.publicId);
                    var res1 = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "OccasionsImage");
                    Occas.Title = obj.Title;
                    Occas.Description = obj.Description;
                    Occas.DisplayOrder = obj.DisplayOrder;

                    Occas.ImageUrl = res1.Url;
                    Occas.publicId = res1.PublicId;

                }
                else
                {

                    Occas.Title = obj.Title;
                    Occas.Description = obj.Description;
                    Occas.DisplayOrder = obj.DisplayOrder;
                }

                _dbContext.occasions.Update(Occas);
                _dbContext.SaveChangesAsync();


            }
            else
            {


                var res = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "OccasionsImage");
                Occasions.Title = obj.Title;
                Occasions.Description = obj.Description;
                Occasions.DisplayOrder = obj.DisplayOrder;
                Occasions.ImageUrl = res.Url;
                Occasions.publicId = res.PublicId;

                _dbContext.occasions.AddAsync(Occasions);
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
            var data = await _dbContext.occasions.FindAsync(id);
            if (data != null)
            {
                _dbContext.occasions.Remove(data);
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
            var data = await _dbContext.occasions.ToListAsync();

            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> GetSingle(int id)
        {
            var data = await _dbContext.occasions.FindAsync(id);
            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Update(int Id, OccasionsRequestModel obj)
        {
            var data = await _dbContext.occasions.FindAsync(Id);
            if (data != null)
            {
                data.Description = obj.Description;
                data.Title = obj.Title;
                
                data.DisplayOrder = obj.DisplayOrder;


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
