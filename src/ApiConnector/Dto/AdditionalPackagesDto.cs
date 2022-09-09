using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiConnector.Dto {
    public class AdditionalPackagesDto {
        public long Id { get; set; } = default!;
        public string Uuid { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Slug { get; set; } = default!;
        public List<PackInstaller> ToInstall { get; set; } = default!;
    }
}
