using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Responses
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public int Status { get; set; }

        public BaseResponse<T> Error(T? _data, string? _message, int _status = 500)
        {
            return new BaseResponse<T>
            {
                IsSuccess = false,
                Data = _data,
                Message = _message,
                Status = _status
            };
        }
        public BaseResponse<T> Success(T? _data, string? _message, int _status = 200)
        {
            return new BaseResponse<T>
            {
                IsSuccess = true,
                Data = _data,
                Message = _message,
                Status = _status
            };
        }
    }
}
