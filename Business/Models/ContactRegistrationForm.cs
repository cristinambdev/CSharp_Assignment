using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class ContactRegistrationForm
{

    [Required (ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "Please, enter a valid name")]
    public string FirstName { get; set; } = null!;

    [Required (ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Please, enter a valid last name")]
    public string LastName { get; set; } = null!;

    [Required (ErrorMessage = "An email is required")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$", ErrorMessage = "Please, enter a valid email with this format: user@domain.com")]
    public string Email { get; set; } = null!;

    [Required (ErrorMessage = "A phone number is required")]
    [RegularExpression(@"^?\(?\d{2,3}?\)??-??\(?\d{9,10}$", ErrorMessage = "Please, enter a valid phone number")]
    public string PhoneNumber { get; set; } = null!;

    [Required (ErrorMessage = "An address is required")]
    [MinLength(2, ErrorMessage = "Please, enter a valid address")]
    public string Address { get; set; } = null!;

    [Required (ErrorMessage = "A post number is required")]
    [RegularExpression(@"^\d{5}$", ErrorMessage = "Please, enter a valid post number")]
    public string PostNumber { get; set; } = null!;

    [Required (ErrorMessage = "A city is required")]
    [MinLength(2, ErrorMessage = "Please, enter a valid city")]
    public string City { get; set; } = null!;

}
