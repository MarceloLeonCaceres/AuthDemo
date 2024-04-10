namespace Models.DTOs
{
    public class UserinfoDto
    {
        public string Badgenumber { get; set; }
        public string? SSN { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public string? Email { get; set; }
        public bool EsAppUser { get; set; }
    }
}
