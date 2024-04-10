using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class DeptoUpdateDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConst.MAX_DEPTNAME_LENGTH, ErrorMessage = ModelConst.ERROR_MSG_MAX_DEPTNAME_LENGTH)]
        public string DeptName { get; set; }
    }
}
