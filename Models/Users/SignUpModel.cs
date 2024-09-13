using System.ComponentModel.DataAnnotations;

namespace kme.Models.Users
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Enter username !")]
        [Display(Name = "Enter UserName :")]
        [StringLength(maximumLength: 7, MinimumLength = 3, ErrorMessage = "Username Length Must Be Max 7 & Min 3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter The Password !")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter The ConfirmPassword !")]
        [Display(Name = "ConfirmPassword :")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter The Email Address !")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter The Gender !")]
        [Display(Name = "Gender :")]
        [MaxLength(1)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter The Profile Image !")]
        [Display(Name = "Profile Image :")]
        public string Uimg { get; set; }
    }
}
