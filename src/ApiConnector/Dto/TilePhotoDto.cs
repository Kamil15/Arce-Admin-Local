using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnector.Dto {
    public class TilePhotoDto {
        public int Id { get; set; } = default!;
        public string Url { get; set; } = default!;
        public int Width { get; set; } = default!;
        public int Height { get; set; } = default!;
    }
}
