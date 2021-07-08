using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class GlobalResponseModel<T>
    {
        public T Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public int TotalRecord { get; set; } = 0;
        public GlobalResponseModel()
        {
            Data = default(T);
        }
        public bool IsSuccess { get; set; } = false;
    }
}
