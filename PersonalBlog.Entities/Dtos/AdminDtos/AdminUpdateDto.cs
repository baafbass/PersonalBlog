using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.AdminDtos
{
    public class AdminUpdateDto
    {
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage ="{0} field is required")]
        [DisplayName("E-mail")]
        [MaxLength(100,ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Email { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Password")]
        [MaxLength(250, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Password { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Security Question")]
        [MaxLength(200, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string SecurityQuestions { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Security Question Answer")]
        [MaxLength(250, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public String SQAnswers { get; set; }
        //
        [Required(ErrorMessage = "{0} is a required field.")]
        [DisplayName("To be Active?")]
        public bool IsActive { get; set; }
        //
        [Required(ErrorMessage = "{0} is a required field.")]
        [DisplayName("To be Deleted?")]
        public bool IsDeleted { get; set; }
    }
}
