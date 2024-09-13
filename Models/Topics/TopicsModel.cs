using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kme.Models.Topics
{
    public class TopicsModel
    {
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            public String EbookId { get; set; }
        [NotMapped]
        public IFormFile AudioFileId { get; set; }

            public string EbookName { get; set; }

            public string AudioName { get; set; }

            public int TotalEbookParts { get; set; }

            public int TotalAudioFiles { get; set; }
        [NotMapped]
        public IFormFile EbookFileld { get; set; }
        [NotMapped]
        public IFormFile Timg { get; set; }
        [NotMapped]
        public IFormFile Yvideo { get; set; }

            [Required]
            public string EbCategory { get; set; }
    }
}
