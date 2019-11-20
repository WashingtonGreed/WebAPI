using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IRepositorio;
using WebAPI.Models;
using WebAPI.Frameworks;
using System.IO;
using System.Net.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [ApiController]
    public class UsuariosController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IConfiguration _configuration;
        private readonly IGaleriaRepositorio _galeriaRepositorio;

      

        public UsuariosController(IUsuarioRepositorio usuarioRepo, IConfiguration configuration, IGaleriaRepositorio galeriaRepo)
        {
            _usuarioRepositorio = usuarioRepo;
            _configuration = configuration;
            _galeriaRepositorio = galeriaRepo;

        }

        [HttpGet]
        [Route("GetAll")]
        [AllowAnonymous]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        }

        [HttpPost]
        [Route("ResetPasswordByEmail")]
        [AllowAnonymous]
        public IActionResult ResetPasswordByEmail([FromForm] Usuario usuario)
        {
            var usu = _usuarioRepositorio.FindByEmail(usuario.Email);

            if (usu != null)
            {
                Random rdn = new Random();

                string novaSenha;

                novaSenha = rdn.Next(10000000, 99999999).ToString();

                usu.Senha = novaSenha;
                Email _email = new Email();
                _usuarioRepositorio.Update(usu);
                return new ObjectResult(_email.SendEmail(usuario));

            }
            return new ObjectResult("Tente novamente mais tarde");
        }

        [HttpPost]
        [Route("FindByEmailSenha")]
        [AllowAnonymous]

        public IActionResult FindByEmailSenha([FromForm] Usuario usuario)
        {
            var usu = _usuarioRepositorio.FindByEmailSenha(usuario.Email, usuario.Senha);
            if (usu != null)
            {
                TokenController obj = new TokenController(_configuration);
                usu.Token = obj.RequestToken(usuario.Email).ToString();
                Update(usu);
                return new ObjectResult(usu);
            }
            return NotFound();

        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null)
                return NotFound();

            return new ObjectResult(usuario);
        }

        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromForm] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            usuario.DataCriacao = DateTime.Now;
            TokenController obj = new TokenController(_configuration);
            usuario.Token = obj.RequestToken(usuario.Email).ToString();

            _usuarioRepositorio.Add(usuario);

            return CreatedAtRoute("GetUsuario", new { id = usuario.Id, }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.Id==0)
                return BadRequest();

            usuario.Nome = usuario.Nome;
            usuario.Foto = usuario.Foto;
            usuario.Email = usuario.Email;
            usuario.Senha = usuario.Senha;
            usuario.Sexo = usuario.Sexo;
            usuario.Telefone = usuario.Telefone;
            usuario.Pais = usuario.Pais;
            usuario.Geolocalizacao = usuario.Geolocalizacao;
            usuario.Token = usuario.Token;

            Usuario _usuario = new Usuario();
            _usuario = usuario;
            _usuarioRepositorio.Update(_usuario);
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioRepositorio.Find(id);

            if (usuario == null)
                return NotFound();

            _usuarioRepositorio.Remove(id);

            return new NoContentResult();
        }


    }
}