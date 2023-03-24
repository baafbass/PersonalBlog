using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SlidersDtos
{
    public class SlidersAddDto
    {
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Title")]
        [MaxLength(40,ErrorMessage = "{0} field must be at maximun {1} characters")]
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
    }
}
