using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Model
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("telefone")]
        public string Telefone { get; set; }
        [Column("usuario_id")]
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
