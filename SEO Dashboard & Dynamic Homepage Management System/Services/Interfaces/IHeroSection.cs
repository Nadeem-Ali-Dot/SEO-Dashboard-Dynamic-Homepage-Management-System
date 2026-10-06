using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces
{
    public interface IHeroSection
    {
        Task<APIResponse> Add(HereSectionReqestModel obj);
        Task<APIResponse> Update(int Id, HereSectionReqestModel obj);
        Task<APIResponse> GetAll();
        Task<APIResponse> GetSingle(int id);
        Task<APIResponse> Delete(int id);
    }
}
