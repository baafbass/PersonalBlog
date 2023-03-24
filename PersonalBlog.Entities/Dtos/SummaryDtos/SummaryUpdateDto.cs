using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SummaryDtos
{
    public class SummaryUpdateDto
    {
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage ="{0} is a required field.")]
        [DisplayName("Summary Information")]
        [MinLength(200,ErrorMessage ="{0} field must be at least {1} characters!")]
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
