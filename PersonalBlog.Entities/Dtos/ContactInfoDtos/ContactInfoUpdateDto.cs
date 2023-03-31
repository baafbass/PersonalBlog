using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.ContactInfoDtos
{
    public class ContactInfoUpdateDto
    {
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage ="{0} field is required")]
        [DisplayName("Phone Number")]
        [MaxLength(30,ErrorMessage ="{0} field must be at maximun {1} characters")]
        public string phoneNumber { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Email")]
        [MaxLength(100, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Email { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("City")]
        [MaxLength(50, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string City { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Adress")]
        [MaxLength(100, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Adress { get; set; }
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
