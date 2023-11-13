using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lucent_Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        [Required]
        [NotMapped]
        public IFormFile CoverPicture { get; set; }
        public string? CoverPicturePath { get; set; }
    }
}
