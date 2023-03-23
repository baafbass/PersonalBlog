using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Shared.Utilities
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;}
        public string  Info { get;}
        public Exception Exception { get; }
    }
}
