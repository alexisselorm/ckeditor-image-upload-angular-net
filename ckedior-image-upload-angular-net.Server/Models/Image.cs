using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ckedior_image_upload_angular_net.Server.Models
{
    [Table("Images")]
    public class Image
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string ModelName { get; set; }


        [Required]
        public int ModelId { get; set; } = 0;

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        public string MimeType { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
