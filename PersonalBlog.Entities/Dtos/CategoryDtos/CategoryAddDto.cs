using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.CategoryDtos
{
    public class CategoryAddDto
    {
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Category Name")]
        [MaxLength(30, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Name { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Category Icon")]
        [MaxLength(150, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string CategoryImg { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Description")]
        [MaxLength(200, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Description { get; set; }
    }
}
