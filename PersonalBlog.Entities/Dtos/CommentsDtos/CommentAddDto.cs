using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.CommentsDtos
{
    public class CommentAddDto
    {
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("First Name")]
        [MaxLength(30, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string FirstName { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Last Name")]
        [MaxLength(30, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string LastName { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Text")]
        [MaxLength(512, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Text { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Article")]
        public int ArticleId { get; set; }
    }
}
