using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class VehiclesService : IVehicles
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICloudinaryService _cloudinaryService;
        public VehiclesService(ApplicationDbContext applicationDb, ICloudinaryService _cloudinaryService)
        {
            _dbContext = applicationDb;
            this._cloudinaryService = _cloudinaryService;
        }
        public async Task<APIResponse> Add(VehiclesRequestmodel obj)
        {
            var Vehicles = new Vehicles();

            if (obj.Id != 0)
            {
                var Vehicle = await _dbContext.vehicles.FindAsync(obj.Id);
                if (obj.ImageUrl != null)
                {
                    await _cloudinaryService.DeleteImageAsync(obj.publicId);
                    var res1 = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "Vehicle");
                    Vehicle.Name = obj.Name;
                    Vehicle.SeatingCapacity = obj.SeatingCapacity;
                    Vehicle.Description = obj.Description;
                    Vehicle.Features = obj.Features;

                    Vehicle.ImageUrl = res1.Url;
                    Vehicle.publicId = res1.PublicId;

                }
                else
                {

                    Vehicle.Name = obj.Name;
                    Vehicle.SeatingCapacity = obj.SeatingCapacity;
                    Vehicle.Description = obj.Description;
                    Vehicle.Features = obj.Features;
                }

                _dbContext.vehicles.Update(Vehicle);
                _dbContext.SaveChangesAsync();


            }
            else
            {


                var res = await _cloudinaryService.UploadImageAsync(obj.ImageUrl, "Vehicle");
                Vehicles.Name = obj.Name;
                Vehicles.SeatingCapacity = obj.SeatingCapacity;
                Vehicles.Description = obj.Description;
                Vehicles.Features = obj.Features;

                Vehicles.ImageUrl = res.Url;
                Vehicles.publicId = res.PublicId;

                _dbContext.vehicles.AddAsync(Vehicles);
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
            var data = await _dbContext.vehicles.FindAsync(id);
            if (data != null)
            {

                _dbContext.vehicles.Remove(data);
                _dbContext.SaveChanges();
                await _cloudinaryService.DeleteImageAsync(data.publicId);
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
            var data = await _dbContext.vehicles.ToListAsync();

            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> GetSingle(int id)
        {
            var data = await _dbContext.vehicles.FindAsync(id);
            return new APIResponse
            {
                IsSuccess = true,
                Result = data,
                statusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<APIResponse> Update(int Id, VehiclesRequestmodel obj)
        {
            var data = await _dbContext.vehicles.FindAsync(Id);
            if (data != null)
            {
                data.Description = obj.Description;
                data.Features = obj.Features;
                data.SeatingCapacity = obj.SeatingCapacity;
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
