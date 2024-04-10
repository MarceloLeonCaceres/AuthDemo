using Models.DTOs;
using Models.Entities;

namespace DataRepository.Interfaces
{
    public interface IUserinfoRepo
    {
        Task<Userinfo?> CreateUserinfoAsync(UserinfoCreateFromBiometricoDto createUserinfo);
        Task<bool> EliminaUserinfo(string badgenumber);
        Task<bool> ExisteUserinfo(string badgenumber);
        Task<Userinfo?> GetUserinfoByBadgenumberAsync(string badgenumber);
        Task<Userinfo?> GetUserinfoByUserIdAsync(int userid);
        Task<List<UserinfoDto>?> GetUsersinfoAsync();
        Task<List<Userinfo>> GetUsersinfoByDeptAsync(int deptId);
        Task<Userinfo?> UpdateUserinfoAsync(Userinfo userinfo);
    }
}
