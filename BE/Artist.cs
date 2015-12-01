using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Artist")]
        [StringLength(30, ErrorMessage = "Artist name must be below 30 characters")]
        public string Name { get; set; }
    }
}
