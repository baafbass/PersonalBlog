using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SocialMediasDtos
{
    public class SocialMediasUpdateDto
    {   
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage = "{0} Social Media Account is required!")]
        [DisplayName("Social Media Name")]
        [MaxLength(30, ErrorMessage = "{0} field must be a maximun of 30 characters")]
        public string MediaName { get; set; }
        //
        [Required(ErrorMessage = "{0} Social Media Account is required!")]
        [DisplayName("Social Media Logo")]
        [MaxLength(150, ErrorMessage = "{0} field must be a maximun of 30 characters")]
        public string MediaLogo { get; set; }
        //
        [Required(ErrorMessage = "{0} Social Media Account is required!")]
        [DisplayName("Social Media Link")]
        [MaxLength(150, ErrorMessage = "{0} field must be a maximun of 30 characters")]
        public string MediaURL { get; set; }
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
