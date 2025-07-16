using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace links.core.DTOs
{
     class WebDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }


    }
    public class WebDetailDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string? ImageUrl { get; set; }
        public string? Coupon { get; set; }

    }
}
