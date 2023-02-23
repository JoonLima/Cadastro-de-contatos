using back_end.Model;

namespace back_end.Interface
{
    public interface IContatoRepositorio
    {
        Task<List<Contato>> ObterContatos();
        Task<List<Contato>> ObterContatosUsuario(int idUsuario);
        Task<Contato> ObterContato(int id);
        Task<Contato> AdicionarContato(Contato contato);
        Task AtualizarContato(Contato contato);
        Task DeletarContato(Contato contato);
    }
}
