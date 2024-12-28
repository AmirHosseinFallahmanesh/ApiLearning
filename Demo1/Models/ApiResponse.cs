using System;
using System.Collections.Generic;

namespace Demo1.Models
{
    public class ApiResponse<T>
    {
        public string Status { get; set; } // "success" or "error"
        public int Code { get; set; } // HTTP status code
        public string Message { get; set; } // Brief message about the response
        public T Data { get; set; } // The actual data returned (if applicable)
        public List<ApiError> Errors { get; set; } // List of error messages (if applicable)
        public DateTime Timestamp { get; set; } // Time of the response

        public ApiResponse()
        {
            Errors = new List<ApiError>();
            Timestamp = DateTime.UtcNow; // Set to current UTC time
            Status = "Success";

        }
    }
}
