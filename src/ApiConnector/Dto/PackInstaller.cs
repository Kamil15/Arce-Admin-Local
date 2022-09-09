using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnector.Dto {
    public class PackInstaller {
        public int Id { get; set; } = default!;
        public string Uuid { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public string Extension { get; set; } = default!;
        public string ServerPath { get; set; } = default!;
        public string LocalPath { get; set; } = default!;

    }
}
