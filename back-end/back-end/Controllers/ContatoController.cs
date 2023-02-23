using back_end.Interface;
using back_end.Model;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/contatos")]
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _repositorio;

        public ContatoController(IContatoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObterContatos()
        {
            var contatos = await _repositorio.ObterContatos();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterContato(int id)
        {
            var contato = await _repositorio.ObterContato(id);
            return contato == null ? NotFound() : Ok(contato);
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> ObterContatosUsuario(int idUsuario)
        {
            var listaContatos  = await _repositorio.ObterContatosUsuario(idUsuario);
            return Ok(listaContatos);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarContato([FromBody]Contato contato)
        {
            var contatoParaAdicionar = await _repositorio.AdicionarContato(contato);
            return contatoParaAdicionar != null ? Created("", contatoParaAdicionar) : BadRequest("Erro ao adicionar contato.");
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarContato([FromBody]Contato contato)
        {
            var contatoParaAtualizar = await _repositorio.ObterContato(contato.Id);

            if (contatoParaAtualizar == null) return BadRequest("Usuario não encontrado.");

            await _repositorio.AtualizarContato(contato);

            return Ok(contatoParaAtualizar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarContato(int id)
        {
            var contatoParaDeletar = await _repositorio.ObterContato(id);

            if (contatoParaDeletar == null) return BadRequest("Usuario não encontrado.");

            await _repositorio.DeletarContato(contatoParaDeletar);

            return NoContent();
        }

    }
}
