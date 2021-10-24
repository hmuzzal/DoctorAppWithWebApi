using System.ComponentModel.DataAnnotations;

namespace DhakaChoiceApiApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11,ErrorMessage = "The phone number must be 11 digits.")]
        [MaxLength(11, ErrorMessage = "The phone number must 11 digits.")]
        public string PhoneNumber { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Password Must be between 5 and 20 characters", MinimumLength = 5)]

        public string Password { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "Password Must be between 5 and 20 characters", MinimumLength = 5)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
