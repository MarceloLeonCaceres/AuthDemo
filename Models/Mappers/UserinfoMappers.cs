using Models.DTOs;
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
                Email = userinfo.Name
            };
        }
    }
}
