using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Shared.Utilities.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus,string info)
        {
            ResultStatus = resultStatus;
            Info = info;
        }
        public Result(ResultStatus resultStatus, string info,Exception exception)
        {
            ResultStatus = resultStatus;
            Info = info;
            Exception = exception;
        }

        public ResultStatus ResultStatus { get; }

        public string Info {get;}

        public Exception Exception {get;}

        //new Result(ResulStatus.Error,"Hata")
    }
}
