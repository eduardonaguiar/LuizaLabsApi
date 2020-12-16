using System.ComponentModel.DataAnnotations;

namespace LuizaLabs.Infra.CrossCutting.Identity.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Campo requirido.")]
        [EmailAddress(ErrorMessage = "O E-mail está em um formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo requirido.")]
        [StringLength(100, ErrorMessage = "O {0} deve estar entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
