using Models.Entities;

namespace Models.DTOs
{
    public class DeptoUsersDto
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public List<UserinfoBNDto>? Userinfos { get; set; }
    }
}
