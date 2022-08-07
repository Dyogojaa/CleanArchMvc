using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email é Requerido")]
        [EmailAddress(ErrorMessage ="Formato de Email Inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="A Senha é Requerida")]        
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max " +
            "{1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

    }
}
