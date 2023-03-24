using PersonalBlog.Shared.Utilities.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Shared.Utilities.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        //new DataResult<ArticlesListDto>(ResultStatus.error,"","Hata")
        public DataResult(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public DataResult(ResultStatus resultStatus,T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, T data, string info)
        {
            ResultStatus = resultStatus;
            Data = data;
            Info = info;
        }
        public DataResult(ResultStatus resultStatus, T data, string info,Exception exception)
        {
            ResultStatus = resultStatus;
            Data = data;
            Info = info;
            Exception = exception;
        }
        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Info { get; }

        public Exception Exception { get; }
    }
}
