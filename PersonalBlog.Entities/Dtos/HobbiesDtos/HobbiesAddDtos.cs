using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.HobbiesDtos
{
    public class HobbiesAddDtos
    {
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("My Hobbies")]
        [MaxLength(300,ErrorMessage = "{0} field must be a maximun of 300 characters")]
        public string Text { get; set; }
    }
}
