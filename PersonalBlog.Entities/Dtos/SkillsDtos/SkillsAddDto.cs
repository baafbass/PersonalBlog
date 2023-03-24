using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SkillsDtos
{
    public class SkillsAddDto
    {
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Skill")]
        [MaxLength(25,ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string SkillName { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Percentage")]
        [Range(0,100,ErrorMessage = "{0} value must be between {1} and {2}")]
        public int Percentage { get; set; }
    }
}
