using System.ComponentModel.DataAnnotations;

namespace PDKLibrary.Models
{
    public class Book
    {
        public int ID { get; set; } //Uneditable

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(50)]
        public string Author { get; set; } = string.Empty;

        public Boolean Available { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        [Display(Name = "Reading Rate")]
        public string ReadingRate { get; set; } = string.Empty;
    }
}