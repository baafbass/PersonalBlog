using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.EducationDtos
{
    class EducationUpdateDto
    {
        [Required]
        //
        public int ID { get; set; }
        //
        [Required]
        [DisplayName("Education Title")]
        [MaxLength(50,ErrorMessage =" {0} must be at maximun {1} characters")]
        public string educationTitle { get; set; }
        //
        [Required]
        [DisplayName("School")]
        [MaxLength(100, ErrorMessage = " {0} must be at maximun {1} characters")]
        public string School { get; set; }
        //
        [Required]
        [DisplayName("Duration")]
        [MaxLength(30, ErrorMessage = " {0} must be at maximun {1} characters")]
        public string Duration { get; set; }
        //
        [Required]
        [DisplayName("GPA")]
        [MaxLength(10, ErrorMessage = " {0} must be at maximun {1} characters")]
        public string GradePointAverage { get; set; }
        //
        [Required]
        [DisplayName("Description")]
        [MaxLength(200, ErrorMessage = " {0} must be at maximun {1} characters")]
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
