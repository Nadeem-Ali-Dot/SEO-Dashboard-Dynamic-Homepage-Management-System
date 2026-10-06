using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class TestimonialsService : ITestimonials
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICloudinaryService _cloudinaryService;

        public TestimonialsService(ApplicationDbContext applicationDb, ICloudinaryService cloudinary)
        {
            _dbContext = applicationDb;
            _cloudinaryService = cloudinary;
        }
        public async Task<APIResponse> Add(TestimonialsRequest obj)
        {
            var Testimonial = new Testimonials();

            if (obj.Id != 0)
            {
                var Testimonials = await _dbContext.testimonials.FindAsync(obj.Id);
                if (obj.CustomerImage != null)
                {
                    await _cloudinaryService.DeleteImageAsync(obj.publicId);
                    var res1 = await _cloudinaryService.UploadImageAsync(obj.CustomerImage, "TestimonialsImage");
                    Testimonials.CustomerName = obj.CustomerName;
                    Testimonials.Rating = obj.Rating;
                    Testimonials.Review = obj.Review;
                    
                    Testimonials.CustomerImage = res1.Url;
                    Testimonials.publicId = res1.PublicId;

                }
                else
                {
                   
                    Testimonials.CustomerName = obj.CustomerName;
                    Testimonials.Rating = obj.Rating;
                    Testimonials.Review = obj.Review;
                }

                _dbContext.testimonials.Update(Testimonials);
                _dbContext.SaveChangesAsync();


            }
            else
            {


                var res = await _cloudinaryService.UploadImageAsync(obj.CustomerImage, "TestimonialsImage");
                Testimonial.CustomerName = obj.CustomerName;
                Testimonial.Rating = obj.Rating;
                Testimonial.Review = obj.Review;
                Testimonial.CustomerImage = res.Url;
                Testimonial.publicId = res.PublicId;

                _dbContext.testimonials.AddAsync(Testimonial);
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
            var data = await _dbContext.testimonials.FindAsync(id);
            if (data != null)
            {
                _dbContext.testimonials.Remove(data);
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
            var data = await _dbContext.testimonials.ToListAsync();

            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> GetSingle(int id)
        {
            var data = await _dbContext.testimonials.FindAsync(id);
            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Update(int Id, Testimonials obj)
        {
            var data = await _dbContext.testimonials.FindAsync(Id);
            if (data != null)
            {
               


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
