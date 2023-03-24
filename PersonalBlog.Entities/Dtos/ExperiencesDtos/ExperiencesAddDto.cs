using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.ExperiencesDtos
{
    public class ExperiencesAddDto
    {
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Experience Title")]
        [MaxLength(50,ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string experienceTitle { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Job Position")]
        [MaxLength(100, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string jobPosition { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Duration")]
        [MaxLength(50, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Duration { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Description")]
        [MaxLength(250, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Description { get; set; }
    }
}
