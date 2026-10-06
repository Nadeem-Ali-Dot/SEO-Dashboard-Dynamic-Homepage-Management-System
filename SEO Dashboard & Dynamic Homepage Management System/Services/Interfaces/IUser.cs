using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces
{
    public interface IUser
    {
        Task<APIResponse> Add(Users obj);
        Task<APIResponse> Update(int Id, Users obj);
        Task<APIResponse> GetAll();
        Task<APIResponse> GetSingle(int id);
        Task<APIResponse> Delete(int id);
    }
}
