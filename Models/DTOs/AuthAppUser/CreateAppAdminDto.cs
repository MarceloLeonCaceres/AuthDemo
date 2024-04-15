using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.AuthAppUser
{
    public class CreateAppAdminDto : PerfilAppAdminDto
    {

        [Required]
        [MinLength(ModelConst.MIN_USERNAME_LENGTH, ErrorMessage = ModelConst.ERROR_MSG_MIN_USERNAME_LENGTH)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*?[0-9]).{8,20}$", 
            ErrorMessage = ModelConst.ERROR_MSG_MIN_USERNAME_LENGTH)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [PasswordPropertyText(true)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*?[0-9]).{8,20}$",
         ErrorMessage = ModelConst.ERROR_MSG_PASSWORD)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }





    }
}
