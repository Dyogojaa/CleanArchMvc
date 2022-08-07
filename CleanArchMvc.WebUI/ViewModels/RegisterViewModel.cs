using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Compare("Password", ErrorMessage = "A Senha não confere")]
        public string ConfirmPassword { get; set; }
    }
}
