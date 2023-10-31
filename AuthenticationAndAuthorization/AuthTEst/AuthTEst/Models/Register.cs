using System.ComponentModel.DataAnnotations;

namespace AuthTEst.Models
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Password and confrmation password did not match")]
        public string ConfirmPassword { get; set; }
    }
}
