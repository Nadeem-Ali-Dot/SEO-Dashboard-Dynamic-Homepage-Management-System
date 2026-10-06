using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class SeoSettingsService : ISeoSettings
    {
        private readonly ApplicationDbContext _dbContext;
        public SeoSettingsService(ApplicationDbContext applicationDb)
        {
            _dbContext = applicationDb;
        }
        public async Task<APIResponse> Add(SeoSettings obj)
        {
            var data =await _dbContext.seoSettings.FindAsync(obj.Id);
            if(data is null)
            {
                _dbContext.seoSettings.AddAsync(obj);
            }
            else
            {
                data.TwitterDescription = obj.TwitterDescription;
                data.OgDescription = obj.OgDescription;
                data.OgTitle = obj.OgTitle;
                data.OgImage = obj.OgImage;
                data.MetaDescription = obj.MetaDescription;
                data.FocusKeywords = obj.FocusKeywords;
                data.CanonicalUrl = obj.CanonicalUrl;
                data.MetaTitle = obj.MetaTitle;
                data.TwitterTitle = obj.TwitterTitle;
                data.TwitterImage = obj.TwitterImage;
                data.RobotsTag = obj.RobotsTag;
            }
            
            _dbContext.SaveChanges();
            return new APIResponse
            {
                IsSuccess = true,
                Result = obj,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Delete(int id)
        {
            var data = await _dbContext.seoSettings.FindAsync(id);
            if (data != null)
            {
                _dbContext.seoSettings.Remove(data);
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
            var data = await _dbContext.seoSettings.ToListAsync();

            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> GetSingle(int id)
        {
            var data = await _dbContext.seoSettings.FindAsync(id);
            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Update(int Id, SeoSettings obj)
        {
            var data = await _dbContext.seoSettings.FindAsync(Id);
            if (data != null)
            {
                data.TwitterDescription = obj.TwitterDescription;
                data.OgDescription = obj.OgDescription;
                data.MetaDescription = obj.MetaDescription;
                data.FocusKeywords = obj.FocusKeywords;
                data.CanonicalUrl = obj.CanonicalUrl;
                data.MetaTitle = obj.MetaTitle;
                data.MetaTitle = obj.MetaTitle;




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
