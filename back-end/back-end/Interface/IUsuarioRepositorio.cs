using back_end.Model;

namespace back_end.Interface
{
    public interface IUsuarioRepositorio
    {

        Task<IEnumerable<Usuario>> ObterUsuarios();
        Task<Usuario> ObterUsuario(int id);
        Task<Usuario> ObterUsuarioPorEmail(string email);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task AtualizarUsuario(Usuario usuario);
        Task DeletarUsuario(Usuario usuario);
    }
}
