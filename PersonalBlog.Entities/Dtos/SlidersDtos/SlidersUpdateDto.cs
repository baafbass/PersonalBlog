using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SlidersDtos
{
    public class SlidersUpdateDto
    {
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Title")]
        [MaxLength(40, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Title { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Short Content")]
        [MaxLength(1000, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string ShortContent { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Content")]
        public string Content { get; set; }
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
