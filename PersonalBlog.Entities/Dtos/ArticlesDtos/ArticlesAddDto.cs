using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.ArticlesDtos
{
    public class ArticlesAddDto
    {
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Title")]
        [MaxLength(100,ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Title { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Overview")]
        [MaxLength(500, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Overview { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Content")]
        public string Content { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Thumbnail")]
        [MaxLength(250, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string Thumbnail { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("SEO Tags")]
        [MaxLength(150, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string SeoTags { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("SEO Description")]
        [MaxLength(150, ErrorMessage = "{0} field must be at maximun {1} characters")]
        public string SeoDescription { get; set; }
        //
        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}
