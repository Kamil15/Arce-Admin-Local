using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnector.Dto {
    public class ReviewDto {
        public ulong Date { get; set; } = default!;
        public int Rating { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Url { get; set; } = default!;
    }
}
