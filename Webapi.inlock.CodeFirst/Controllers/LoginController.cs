using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Webapi.inlock.CodeFirst.Domains;
using Webapi.inlock.CodeFirst.Interfaces;
using Webapi.inlock.CodeFirst.ViewModels;

namespace Webapi.inlock.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController() 
        {
            _usuarioRepository= new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
               Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha!);
                if(usuarioBuscado == null) 
                {
                    return StatusCode(401, "Email ou senha inválidos!");
                }

                //Fazer a lógica de criacão do Token 
                //configurção do jwt na program.cs

                //Caso Encontre o usuario buscado, prossegue para a criação do Token

                // 1º - Definir as informações(Claims) que serão fornecidas no token (payload)

                var Claims = new[]
               {
                    //formato da Claim(tipo, valor)
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TiposUsuario.Titulo.ToString()),
                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Perso","ValorPersonalizado")
               };

                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inlock-chave-autenticacao-webapi-dev"));

                //3º - Definir as credencais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar o token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "Webapi.Inlock.CodeFirst",

                    //destinatário
                    audience: "Webapi.Inlock.CodeFirst",

                    //dados definidos nas claims (Payload)
                    claims: Claims,

                    //tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds

                );

                //5º - retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
                //return Ok(usuarioBuscado);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
