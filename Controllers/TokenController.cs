using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.IRepositorio;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {

        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public string RequestToken( string email)
        {

            if (!String.IsNullOrWhiteSpace(email))
            {
                var claims = new[]
                {
                     new Claim(ClaimTypes.Name, email)
                };

                //recebe uma instancia da classe SymmetricSecurityKey 
                //armazenando a chave de criptografia usada na criação do token
                var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                //recebe um objeto do tipo SigninCredentials contendo a chave de 
                //criptografia e o algoritmo de segurança empregados na geração 
                // de assinaturas digitais para tokens
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                     issuer: "SkyDawn",
                     audience: "SkyDawn",
                     claims: claims,
                     expires: DateTime.Now.AddDays(90),
                     signingCredentials: creds);

                string tken = new JwtSecurityTokenHandler().WriteToken(token);

                return tken;

              
            }
            return "Credenciais inválidas...";
        }
    }
}