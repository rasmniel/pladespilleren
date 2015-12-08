using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Email must be below 30 characters")]
        public string Email { get; set; }

        public virtual Vinyl Vinyl { get; set; }
    }
}
