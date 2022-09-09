using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnector.Dto {
    public class GameDto {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public string Version { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<OsDto> OsList { get; set; } = default!;
        public string Rating { get; set; } = default!;
        public List<string> Genres { get; set; } = default!;
        public int size { get; set; } //Megabytes
        public List<GameScreenDto> Screens { get; set; } = default!;
        public List<OsGameDownloadDto> DownloadUrl { get; set; } = default!;
        public List<AdditionalPackagesDto> AdditionalPackages { get; set; } = default!;
        public List<ReviewDto> Reviews { get; set; } = default!;
        public TilePhotoDto TilePhoto { get; set; } = default!;
        public CoverPhotoDto CoverPhoto { get; set; } = default!;
        public bool IsWeb { get; set; } = false;
        public string RunFrom { get; set; } = default!; // path or url
    }
}
