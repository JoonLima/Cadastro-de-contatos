using back_end.Interface;
using back_end.JWT;
using back_end.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace back_end.Controllers
{
    
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _repositorio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JWTSettings _jwtSettings;


        public UsuarioController(IUsuarioRepositorio repositorio, SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager, IOptions<JWTSettings> jwtSettings)
        {
            _repositorio = repositorio;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> ObterUsuarios()
        {
            var usuarios = await _repositorio.ObterUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuario(int id)
        {

            var usuario =  await _repositorio.ObterUsuario(id);

            return usuario != null ? Ok(usuario) : NotFound("Usuario não encontrado.");

        }
        [AllowAnonymous]
        [HttpPost("nova-conta")]
        public async Task<IActionResult> AdicionaUsuario([FromBody]Usuario usuario)
        {

            var userExists = await _userManager.FindByEmailAsync(usuario.Nome);

            if (userExists is not null) return BadRequest("O usuário já existe.");

            IdentityUser user = new()
            {
                Email = usuario.Email,
                UserName = usuario.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuario.Senha);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, false);

            await _repositorio.AdicionarUsuario(usuario);

            return Created("", usuario);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizaUsuario([FromBody]Usuario usuario)
        {
            var usuarioParaAtualizar = await _repositorio.ObterUsuario(usuario.Id);

            if (usuarioParaAtualizar == null) return NotFound("Usuário não encontrado.");

            usuarioParaAtualizar.Nome = usuario.Nome;
            usuarioParaAtualizar.Email = usuario.Email;
            usuarioParaAtualizar.Senha = usuario.Senha;

            await _repositorio.AtualizarUsuario(usuarioParaAtualizar);

            return Ok("Usuário alterado com sucesso.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaUsuario(int id)
        {
            var usuarioParaDeletar = await _repositorio.ObterUsuario(id);

            if (usuarioParaDeletar == null) return NotFound("Usuário não encontrado");

            await _repositorio.DeletarUsuario(usuarioParaDeletar);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("entrar")]
        public async Task<ActionResult> Login(Login loginUser)
        {

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Senha, false, true);

            var usuarioToken = await _repositorio.ObterUsuarioPorEmail(loginUser.Email);

            if (result.Succeeded)
            {
                var tokenUsuario = await GerarToken(loginUser.Email);

                return Ok(new
                {
                    token = tokenUsuario,
                    usuario = usuarioToken
                });
            }

            return BadRequest();
        }

        private async Task<string> GerarToken(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", usuario.Id.ToString())
                }),
                Issuer = _jwtSettings.Emissor,
                Audience = _jwtSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token =  tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return token;

            

        }

    }
}
