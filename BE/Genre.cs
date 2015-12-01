using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Genre")]
        [StringLength(20, ErrorMessage = "Genre name must be below 20 characters")]
        public string Name { get; set; }
    }
}
