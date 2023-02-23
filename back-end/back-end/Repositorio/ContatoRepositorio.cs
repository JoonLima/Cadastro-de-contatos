using back_end.Data;
using back_end.Interface;
using back_end.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoDeDados _bancoDeDados;

        public ContatoRepositorio(BancoDeDados bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public async Task<List<Contato>> ObterContatos()
        {
            return await _bancoDeDados.Contatos.ToListAsync();
        }

        public async Task<Contato> AdicionarContato(Contato contato)
        {
            await _bancoDeDados.Contatos.AddAsync(contato);
            await _bancoDeDados.SaveChangesAsync();
            return contato;
        }

        public async Task AtualizarContato(Contato contato)
        {
            var contatoParaAtualizar =  _bancoDeDados.Contatos.FirstOrDefault(x => x.Id == contato.Id);

            if (contatoParaAtualizar == null) throw new Exception("Erro ao atualizar contato.");

            contatoParaAtualizar.Nome = contato.Nome;
            contatoParaAtualizar.Email = contato.Email;
            contatoParaAtualizar.Telefone = contato.Telefone;

            _bancoDeDados.Contatos.Update(contatoParaAtualizar);
            await _bancoDeDados.SaveChangesAsync();
        }

        public async Task DeletarContato(Contato contato)
        {
            _bancoDeDados.Remove(contato);
            await _bancoDeDados.SaveChangesAsync();

        }

        public Task<List<Contato>> ObterContatosUsuario(int idUsuario)
        {
            return _bancoDeDados.Contatos.Where(x => x.UsuarioId == idUsuario).ToListAsync();
        }

        public async Task<Contato> ObterContato(int id)
        {
            var contato = _bancoDeDados.Contatos.FirstOrDefault(x => x.Id == id);
            return contato;
        }
    }
}
