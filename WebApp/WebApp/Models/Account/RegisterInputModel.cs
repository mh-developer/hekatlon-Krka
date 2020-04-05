using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Account
{
    public class RegisterInputModel
    {
        [Required]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Priimek")]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required] 
        [Display(Name = "Podjetje")]
        public string Company { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Geslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ponovno vnesite geslo")]
        [Compare("Password", ErrorMessage = "Geslo in potrditveno geslo se ne ujemata.")]
        public string ConfirmPassword { get; set; }
    }
}