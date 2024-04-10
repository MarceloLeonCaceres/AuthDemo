using Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class DeptoCreateDto
    {
        [Required]
        [MaxLength(ModelConst.MAX_DEPTNAME_LENGTH, ErrorMessage = ModelConst.ERROR_MSG_MAX_DEPTNAME_LENGTH)]
        public required string DeptName { get; set; }
        public int IdPadre { get; set; }

        public Department ToDepartmentFromCreate()
        {
            throw new NotImplementedException();
        }
    }
}
