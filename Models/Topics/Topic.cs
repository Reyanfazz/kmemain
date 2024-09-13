using System.ComponentModel.DataAnnotations;

namespace kme.Models.Topics
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public String EbookId { get; set; }

        public String AudioFileId { get; set; }

        public string EbookName { get; set; }

        public string AudioName { get; set; }

        public int TotalEbookParts { get; set; }

        public int TotalAudioFiles { get; set; }

        public String EbookFileld { get; set; }

        public String Timg { get; set; }

        public String Yvideo { get; set; }

        [Required]
        public string EbCategory { get; set; }
    }
}
