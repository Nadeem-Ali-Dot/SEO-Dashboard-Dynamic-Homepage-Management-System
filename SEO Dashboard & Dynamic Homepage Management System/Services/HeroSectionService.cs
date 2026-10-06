using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class HeroSectionService : IHeroSection
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ICloudinaryService _cloudinaryService;

        public HeroSectionService(ApplicationDbContext applicationDb, ICloudinaryService cloudinaryService)
        {
            _dbContext = applicationDb;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<APIResponse> Add(HereSectionReqestModel obj)
        {
            var data = new HeroSection();

            if (obj.Id != 0)
            {
                var hero = await _dbContext.heroSections.FindAsync(obj.Id);
                if (obj.ImageUrl != null)
                {
                    await _cloudinaryService.DeleteImageAsync(obj.publicId);
                    var res1 = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "HeroImage");
                    hero.Heading = obj.Heading;
                    hero.SubHeading = obj.SubHeading;
                    hero.ImageUrl = res1.Url;
                    hero.publicId = res1.PublicId;
                    hero.ButtonLink = obj.ButtonLink;
                    hero.ButtonText = obj.ButtonText;

                }
                else
                {
                    hero.Heading = obj.Heading;
                    hero.SubHeading = obj.SubHeading;
                  
                    hero.ButtonLink = obj.ButtonLink;
                    hero.ButtonText = obj.ButtonText;
                }

                _dbContext.heroSections.Update(hero);
                _dbContext.SaveChangesAsync();


            }
            else
            {


                var res = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "HeroImage");
                data.Heading = obj.Heading;
                data.SubHeading = obj.SubHeading;
                data.ImageUrl = res.Url;
                data.publicId = res.PublicId;
                data.ButtonLink = obj.ButtonLink;
                data.ButtonText = obj.ButtonText;

                _dbContext.heroSections.AddAsync(data);
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
            var data = await _dbContext.heroSections.FindAsync(id);
            if (data != null)
            {
                _dbContext.heroSections.Remove(data);
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
                var data = await _dbContext.heroSections.ToListAsync();

            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> GetSingle(int id)
        {
            var data = await _dbContext.heroSections.FindAsync(id);
            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Update(int Id, HereSectionReqestModel obj)
        {
            var data = await _dbContext.heroSections.FindAsync(Id);
            if (data != null)
            {
                data.Heading = obj.Heading;
                data.SubHeading = obj.SubHeading;
                data.ButtonLink = obj.ButtonLink;
                data.ButtonText = obj.ButtonText;


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
