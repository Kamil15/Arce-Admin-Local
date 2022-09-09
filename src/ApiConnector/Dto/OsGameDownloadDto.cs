using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnector.Dto {
    public class OsGameDownloadDto {
        public OsDto Os { get; set; } = default!;
        public string DownloadUrl { get; set; } = default!;
    }
}
