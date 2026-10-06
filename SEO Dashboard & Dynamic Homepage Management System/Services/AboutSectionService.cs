using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class AboutSectionService : Iaboutsection
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICloudinaryService _cloudinaryService;
        public AboutSectionService(ApplicationDbContext applicationDb,ICloudinaryService cloudinary)
        {
            _dbContext = applicationDb;
            _cloudinaryService = cloudinary;
        }
        public async Task<APIResponse> Add(AboutRequestmodel obj)
        {
            var data = new AboutSection();

            if (obj.Id != 0)
            {
                var about =await _dbContext.aboutSections.FindAsync(obj.Id); 
                if(obj.ImageUrl != null)
                {
                    await _cloudinaryService.DeleteImageAsync(obj.publicId);
                  var  res1 = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "AboutImage");
                    about.Title = obj.Title;
                    about.Description = obj.Description;
                    about.ImageUrl = res1.Url;
                    about.publicId = res1.PublicId;

                }
                else
                {
                    about.Title = obj.Title;
                    about.Description = obj.Description;
                }

                _dbContext.aboutSections.Update(about);
                _dbContext.SaveChangesAsync();


            }
            else
            {

          
            var res = await _cloudinaryService.UploadImageAsync(obj.ImageUrl,"AboutImage");
            data.Title = obj.Title;
            data.Description = obj.Description;
            data.ImageUrl = res.Url;
            data.publicId = res.PublicId;

            _dbContext.aboutSections.AddAsync(data);
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
            var data = await _dbContext.aboutSections.FindAsync(id);
            if (data != null)
            {
                _dbContext.aboutSections.Remove(data);
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
            var data = await _dbContext.aboutSections.ToListAsync();

            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> GetSingle(int id)
        {
            var data = await _dbContext.aboutSections.FindAsync(id);
            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Update(int Id, AboutSection obj)
        {
            var data = await _dbContext.aboutSections.FindAsync(Id);
            if (data != null)
            {
                data.Title = obj.Title;
                data.Description = obj.Description;
                data.ImageUrl = obj.ImageUrl;

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
