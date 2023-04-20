using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Admin:EntityBase,IEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityQuestions { get; set; }
        public String SQAnswers { get; set; }
    }
}
