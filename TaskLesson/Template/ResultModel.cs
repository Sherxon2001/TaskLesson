using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLesson.Template
{
    public class ResultModel<T>
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
