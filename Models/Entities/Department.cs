namespace Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public int IdPadre { get; set; }
        public List<Userinfo>? Userinfos { get; } = new List<Userinfo>();
    }
}
