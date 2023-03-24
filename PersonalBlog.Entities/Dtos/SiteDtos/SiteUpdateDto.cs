using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SiteDtos
{
   public class SiteUpdateDto
    {
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Site Name")]
        [MaxLength(30, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string siteName { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Site Keywords")]
        [MaxLength(150, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string siteKeywords { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Logo")]
        [MaxLength(150, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Logo { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Logo Title")]
        [MaxLength(20, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string LogoTitle { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Description")]
        [MaxLength(150, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Description { get; set; }
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
