using back_end.Data;
using back_end.Interface;
using back_end.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoDeDados _bancoDeDados;

        public UsuarioRepositorio(BancoDeDados bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            await _bancoDeDados.AddAsync(usuario);
            await _bancoDeDados.SaveChangesAsync();
            return usuario;
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _bancoDeDados.Update(usuario);
            await _bancoDeDados.SaveChangesAsync();
        }

        public async Task DeletarUsuario(Usuario usuario)
        {
            _bancoDeDados.Remove(usuario);
            await _bancoDeDados.SaveChangesAsync();
        }

        public async Task<Usuario> ObterUsuario(int id)
        {
            return await _bancoDeDados.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _bancoDeDados.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

        }

        public async Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            return await _bancoDeDados.Usuarios.ToListAsync();
        }
    }
}
