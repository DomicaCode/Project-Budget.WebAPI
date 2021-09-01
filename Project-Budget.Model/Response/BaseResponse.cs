using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Model.Response
{
    public class BaseResponse
    {
        public string Error { get; set; }

        public bool? IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
