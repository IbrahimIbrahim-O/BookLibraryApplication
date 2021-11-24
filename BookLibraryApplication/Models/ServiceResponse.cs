using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }

    public class MessageOut
    {
        public string Message { get; set; } = null;
        public bool IsSuccessful { get; set; } = false;
    }
}
