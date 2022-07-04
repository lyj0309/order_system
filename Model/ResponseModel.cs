using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public ResponseModel()
        {
            IsSuccess = true;
        }
        public ResponseModel(bool isSuccess,string error)
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessage = error;
        }
    }
}
