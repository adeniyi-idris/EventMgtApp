using EMA.Data;
using EMA.Enums;
using System.ComponentModel.DataAnnotations;

namespace EMA.DTO
{
    public class RoleDto
    {
        [Required]
        public Enums.Role Roles { get; set; }
        
    }
}
