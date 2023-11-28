using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Result
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}
