using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Infra.CrossCutting.ViewModels
{
    public class ViewModelRegisterRequest
    {
        [Required(ErrorMessage = "E-mail is required.")]
        [EmailAddress(ErrorMessage = "Invalid e-mail format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(10, ErrorMessage = "The password needs to have between 6 and 10 characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required.")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

    }
}
