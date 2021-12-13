using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaulgMessageForStatuesCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

          private string GetDefaulgMessageForStatuesCode(int statusCode)
        {
            return statusCode switch 
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resorse found , it was not ",
                500 => "Errors are the path to the dark side. Errors lead to anger ,anger leads to heat,  heats leads to career change ",
                _ => null 
                    

            };
        }
    }
}