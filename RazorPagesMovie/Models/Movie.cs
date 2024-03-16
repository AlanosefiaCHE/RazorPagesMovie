using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    public int Id { get; set; }

    //The [Required] and [MinimumLength] attributes indicate that a property must have a value.
    //Nothing prevents a user from entering white space to satisfy this validation.
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; } = string.Empty;
    // Displays Release date instead of ReleaseDate in webpage
    [Display(Name = "Release Date")]
    // Only the date is displayed, not time information.
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    //The [RegularExpression] attribute is used to limit what characters can be input. In the Genre code
    //Must only use letters.
    //The first letter must be uppercase. White spaces are allowed, while numbers and special characters aren't allowed.
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    public string? Genre { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    //data annotation enables Entity Framework Core to correctly map Price to currency in the database
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    // This is for the second migration
    //The RegularExpression Rating:
    //Requires that the first character be an uppercase letter.
    //Allows special characters and numbers in subsequent spaces. "PG-13" is valid for a rating, but fails for a Genre.
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string Rating { get; set; } = string.Empty;
}