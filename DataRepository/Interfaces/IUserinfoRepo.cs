using Models.DTOs;
using Models.DTOs.AuthAppUser;
using Models.Entities;

namespace DataRepository.Interfaces
{
    public interface IUserinfoRepo
    {
        Task<Userinfo?> GetUserinfoByBadgenumberAsync(string badgenumber);
        Task<UserinfoDto?> GetUserinfoByUserIdAsync(int userid);
        Task<List<UserinfoDto>?> GetUsersinfoAsync();
        Task<List<Userinfo>> GetUsersinfoByDeptAsync(int deptId);
        Task<List<SelectUserDeptoDto>?> GetUsersinfoSeleccionables(int deptId, int otAdmin);
        Task<Userinfo?> CreateUserinfoAsync(UserinfoCreateFromBiometricoDto createUserinfo);
        Task<Userinfo?> UpdateUserinfoAsync(Userinfo userinfo); 
        Task<bool> EliminaUserinfo(string badgenumber);
        Task<bool> ExisteUserinfo(string badgenumber);
        Task<List<CreateAppUserDeUserinfoDto>?> GetUserinfosValidosAppUser();
    }
}
