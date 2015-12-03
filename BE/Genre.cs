using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Genre : INameable
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Genre")]
        [StringLength(25, ErrorMessage = "Genre name must be below 25 characters")]
        public string Name { get; set; }
    }
}
