using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.APIs.Errors
{
    public class BaseErrorApiResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }

        public BaseErrorApiResponse(int code, string? _message = null)
        {
            statusCode = code;
            if (string.IsNullOrEmpty(_message))
                _message = SetMessage(code);

            message = _message;
        }

        private string SetMessage(int code)
        {
            return code switch
            {
                400 => "Bad Request",
                401 => "UnAuthorized",
                403 => "No Permission",
                404 => "Resource Not Found",
                405 => "Method not allowed",
                500 => "Server sends his Regards :)",
                _ => "error"
            };
        }
    }
}
