using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [MaxLength(12)]
        [Column("senha")]
        public string Senha { get; set; }

        public virtual List<Contato>? Contatos { get; set; }

    }
}
