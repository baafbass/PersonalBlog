using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.HobbiesDtos
{
    public class HobbiesUpdateDtos
    {
        [Required]
        public int ID { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("My Hobbies")]
        [MaxLength(300, ErrorMessage = "{0} field must be a maximun of 300 characters")]
        public string Text { get; set; }
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
