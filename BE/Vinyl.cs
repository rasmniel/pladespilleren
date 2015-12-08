using System;
using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Vinyl
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Album"), Required]
        [StringLength(50, ErrorMessage = "Album name must be below 50 characters")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "URL must be below 150 characters")]
        public string CoverUrl { get; set; }

        [Required]
        [YearRange("1900")] // See custom inner class.
        public int Year { get; set; }

        [Display(Name = "Dkk incl. VAT"), Required]
        [Range(50, 1000, ErrorMessage = "Price must be between 50 & 1000")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }

        [Display(Name = "Dkk excl. VAT")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double CompanyPrice
        {
            get
            {
                return Price * 0.8;
            }
        }

        public virtual Artist Artist { get; set; }

        public virtual Genre Genre { get; set; }


        // Custom inner RangeAttribute class
        private class YearRangeAttribute : RangeAttribute
        {
            private static readonly string ThisYear = DateTime.Now.Year.ToString();

            public YearRangeAttribute(string startingYear)
                : base(typeof(int), startingYear, ThisYear)
            {
                ErrorMessage = "Year must be after " + startingYear + " & before " + ThisYear + 1;
            }
        }
    }
}
