namespace Models.DTOs.AuthAppUser
{
    public class CreateAppUserDeUserinfoDto
    {
        public int UserinfoId { get; set; }
        public string Badgenumber { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
    }
}
