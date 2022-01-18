using System.Collections.Generic;

namespace API.Errors
{
    public class APIValidationError : ApiResponse
    {
        public APIValidationError() : base(400)
        {

        }
        public IEnumerable<string> Errors { get; set;}
    }
}