using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces
{
    public interface IRole
    {
        Task<APIResponse> Add(Roles obj);
        Task<APIResponse> Update(int Id, Roles obj);
        Task<APIResponse> GetAll();
        Task<APIResponse> GetSingle(int id);
        Task<APIResponse> Delete(int id);
    }
}
