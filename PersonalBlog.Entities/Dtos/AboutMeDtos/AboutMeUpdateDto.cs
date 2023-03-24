using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.AboutMeDtos
{
    public class AboutMeUpdateDto
    {
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("First Name")]
        [MaxLength(20,ErrorMessage ="{0} must be at maximun {1} characters")]
        public string FirstName { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Last Name")]
        [MaxLength(20, ErrorMessage = "{0} must be at maximun {1} characters")]
        public string LastName { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Profil Picture")]
        [MaxLength(250, ErrorMessage = "{0} must be at maximun {1} characters")]
        public string profilPicture { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Job")]
        [MaxLength(50, ErrorMessage = "{0} must be at maximun {1} characters")]
        public string Job { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Job Icon")]
        [MaxLength(150, ErrorMessage = "{0} must be at maximun {1} characters")]
        public string JobIcon { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Birthday")]
        [MaxLength(20, ErrorMessage = "{0} must be at maximun {1} characters")]
        public string Birthday { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("CV")]
        [MaxLength(250, ErrorMessage = "{0} must be at maximun {1} characters")]
        public string CV { get; set; }
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
