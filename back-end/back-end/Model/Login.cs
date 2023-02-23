using System.ComponentModel.DataAnnotations;

namespace back_end.Model
{
    public class Login
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
