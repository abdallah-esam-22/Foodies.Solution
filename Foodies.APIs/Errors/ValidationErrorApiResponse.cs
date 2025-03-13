using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.APIs.Errors
{
    public class ValidationErrorApiResponse : BaseErrorApiResponse
    {
        public Dictionary<string, List<string>> Errors { get; set; }

        public ValidationErrorApiResponse() : base(400)
        {
            Errors = new Dictionary<string, List<string>>();
        }
    }
}
