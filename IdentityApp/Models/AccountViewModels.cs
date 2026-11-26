using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Атыңызды енгізіңіз")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Тегіңізді енгізіңіз")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email енгізіңіз")]
        [EmailAddress(ErrorMessage = "Email форматы дұрыс емес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Құпиясөзді енгізіңіз")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Құпиясөздер сәйкес келмейді.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email енгізіңіз")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Құпиясөзді енгізіңіз")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}