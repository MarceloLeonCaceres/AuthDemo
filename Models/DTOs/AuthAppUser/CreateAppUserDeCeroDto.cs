using Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.AuthAppUser
{
    public class CreateAppUserDeCeroDto
    {
        [Required]
        [MaxLength(ModelConst.MAX_BADGENUMBER_LENGTH, ErrorMessage = ModelConst.ERROR_MSG_MAX_BADGENUMBER_LENGTH)]
        [RegularExpression(@"^[1-9]{0,9}$", ErrorMessage = "Debe ser un valor numérico y no empezar con 0 (cero)")]
        public string Badgenumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(ModelConst.MAX_NAME_LENGTH, ErrorMessage = ModelConst.ERROR_MSG_MAX_NAME_LENGTH)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(ModelConst.MIN_SSN_LENGTH, ErrorMessage = ModelConst.ERROR_MSG_MIN_SSN_LENGTH)]
        [MaxLength(ModelConst.MAX_SSN_LENGTH, ErrorMessage = ModelConst.ERROR_MSG_MAX_SSN_LENGTH)]
        public string SSN { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        

    }
}
