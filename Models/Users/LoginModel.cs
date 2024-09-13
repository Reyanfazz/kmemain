using System.ComponentModel.DataAnnotations;

namespace kme.Models.Users
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter Valid Email Id !")]
        [Display(Name = "Email :")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Password !")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
