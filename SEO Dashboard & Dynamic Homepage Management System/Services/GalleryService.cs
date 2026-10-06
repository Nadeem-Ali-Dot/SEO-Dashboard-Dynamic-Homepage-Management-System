using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class GalleryService : IGallery
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICloudinaryService _cloudinaryService;
        public GalleryService(ApplicationDbContext applicationDb, ICloudinaryService _cloudinaryService)
        {
            _dbContext= applicationDb;
            this._cloudinaryService = _cloudinaryService;
        }
        public async Task<APIResponse> Add(galleryRequst obj)
        {
            var Gallery = new Gallery();

            if (obj.Id != 0)
            {
                var Gall = await _dbContext.galleries.FindAsync(obj.Id);
                if (obj.ImageUrl != null)
                {
                    await _cloudinaryService.DeleteImageAsync(obj.publicId);
                    var res1 = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "Gallery");
                    Gall.AltText = obj.AltText;
                    Gall.DisplayOrder = obj.DisplayOrder;            
                    Gall.ImageUrl = res1.Url;
                    Gall.publicId = res1.PublicId;

                }
                else
                {

                    Gall.AltText = obj.AltText;
                    Gall.DisplayOrder = obj.DisplayOrder;
                }

                _dbContext.galleries.Update(Gall);
                _dbContext.SaveChangesAsync();


            }
            else
            {


                var res = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "Vehicle");
                Gallery.AltText = obj.AltText;
                Gallery.DisplayOrder = obj.DisplayOrder;
                Gallery.ImageUrl = res.Url;
                Gallery.publicId = res.PublicId;

                _dbContext.galleries.AddAsync(Gallery);
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
             var data = await _dbContext.galleries.FindAsync(id);
            if (data != null) {
                _dbContext.galleries.Remove(data);
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
            var data = await _dbContext.galleries.ToListAsync();

            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> GetSingle(int id)
        {
            var data = await _dbContext.galleries.FindAsync(id);
            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Update(int Id, galleryRequst obj)
        {
           var data = await _dbContext.galleries.FindAsync(Id);
            if (data != null)
            {
             
                data.AltText = obj.AltText;
                data.DisplayOrder = obj.DisplayOrder;
                _dbContext.SaveChanges();

                return  new APIResponse { IsSuccess = true, Result = data, statusCode = System.Net.HttpStatusCode.OK };
            }
            else
            {
                return new APIResponse { IsSuccess = true, Result = null, statusCode = System.Net.HttpStatusCode.NotFound };
            }
        }
    }
}
