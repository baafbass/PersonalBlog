using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.AdminDtos
{
    public class AdminLoginDto
    {
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "{0} field is required !")]
        [MaxLength(100,ErrorMessage ="{0} field has maximum of {1} characters")]
        [MinLength(10,ErrorMessage = "{0} field has a minimum of {1} characters")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} field is required !")]
        [MaxLength(20,ErrorMessage = "{0} field has a maximum of {1} characters")]
        [MinLength(4,ErrorMessage = "{0} field has a minimum of {1} characters")]
        public string Password { get; set; }
    }
}
