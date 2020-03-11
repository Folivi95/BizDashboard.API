using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizDashboard.API.Data
{
    public class PaginatedResponse<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
        public PaginatedResponse(IEnumerable<T> data, int i, int len)
        {
            // skip i page, with len of data
            Data = data.Skip((i - 1) * len).Take(len).ToList();
            Total = data.Count();
        }
    }
}
