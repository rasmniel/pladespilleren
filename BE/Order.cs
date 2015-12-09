using System;
using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual Vinyl Vinyl { get; set; }
    }
}
