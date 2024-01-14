using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.src.Shared
{
    public class CustomException : Exception
    {
        public int StatusCode { get; }

        public CustomException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public static CustomException NotFound(string message = "Item is not found")
        {
            return new CustomException(404, message);
        }

        public static CustomException BadRequest(string message = "Cannot perform the action")
        {
            return new CustomException(400, message);
        }

        public static CustomException UnAuthorized(string message = "Cannot log in")
        {
            return new CustomException(401, message);
        }
    }

}