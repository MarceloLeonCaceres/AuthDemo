using Models.DTOs;
using Models.DTOs.AuthAppUser;
using Models.Entities;

namespace Models.Mappers
{
    public static class UserinfoMappers
    {
        public static UserinfoDto ToUserinfoDto(this Userinfo userinfo)
        {
            return new UserinfoDto
            {
                Badgenumber = userinfo.Badgenumber,
                SSN = userinfo.SSN,
                Name = userinfo.Name,
                DeptName = userinfo.Department.DeptName,
                Email = userinfo.Name,
                EsAppUser = userinfo.AppUser != null,
            };
        }

        public static Userinfo ToUserinfo(this CreateAppUserDeCeroDto createDeAppUser)
        {
            return new Userinfo
            {
                Badgenumber = createDeAppUser.Badgenumber,
                Name = createDeAppUser.Name,
                SSN = createDeAppUser.SSN,
                DepartmentId = createDeAppUser.DepartmentId,
                Email = createDeAppUser.Email,
                
            };
        }
        public static Userinfo ToUserinfo(this CreateAppUserDeUserinfoDto createDeAppUser)
        {
            return new Userinfo
            {
                UserinfoId = createDeAppUser.UserinfoId,
                Badgenumber = createDeAppUser.Badgenumber,
                SSN = createDeAppUser.SSN,
                Email = createDeAppUser.Email,
            };
        }

        public static SelectUserDeptoDto ToSelectDto(this Userinfo userinfo)
        {
            return new SelectUserDeptoDto
            {
                Badgenumber = userinfo.Badgenumber,
                Name = userinfo.Name,
                DeptName = userinfo.Department.DeptName
            };
        }
    }
}
