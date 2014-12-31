namespace PhotoGallery.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Content { get; set; }

        public int PhotoId { get; set; }

        public Photo Photo { get; set; }
    }
}
