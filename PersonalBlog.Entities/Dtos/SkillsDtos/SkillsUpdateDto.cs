using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SkillsDtos
{
    public class SkillsUpdateDto
    {
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Skill Name")]
        [MaxLength(25, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string SkillName { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Percentage")]
        public int Percentage { get; set; }
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
