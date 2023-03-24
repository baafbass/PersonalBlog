using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.ContactMeDtos
{
   public class ContactMeAddDto
    {
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("First Name")]
        [MaxLength(30,ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string FirstName { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Last Name")]
        [MaxLength(30, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string LastName { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Email Adress")]
        [MaxLength(100, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string EmailAdress { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Subject")]
        [MaxLength(50, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Subject { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Message")]
        [MaxLength(512, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Message { get; set; }
    }
}
