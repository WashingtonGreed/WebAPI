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


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaleriaController : Controller
    {

        private readonly IGaleriaRepositorio _galeriaRepositorio;

        public GaleriaController(IGaleriaRepositorio galeriaRepo)
        {
            _galeriaRepositorio = galeriaRepo;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Galeria> GetAll()

        {
            return _galeriaRepositorio.GetAll();
        }

        [HttpPost]
        [Route("Upload")]
        public IActionResult Upload([FromForm] Galeria galeria)
        {
            Galeria g = new Galeria();
            g = galeria;

            string caminho = "./USUARIO/" + galeria.IdUsuario.ToString();

            if (!Directory.Exists(@caminho))
            {
                Directory.CreateDirectory(@caminho);
                Directory.CreateDirectory(caminho+"/GALERIA");
            }
            caminho += "/Galeria/" + g.FotoNome;
            g.Caminho = caminho;
            var bytes =  Convert.FromBase64String(g.Foto);
            if (g.FotoPerfil) {
                caminho = "./USUARIO/" + galeria.IdUsuario.ToString() + "/" + g.FotoNome;
                    }
            using (var imageFile = new FileStream(caminho, FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
            g.DataCriacao = DateTime.Now;
            g.IdUsuario = galeria.IdUsuario;
                    _galeriaRepositorio.Add(g);
                            
                return  Ok(new { count = g.Caminho });
        }

        [HttpPost]
        [Route("FindByUsuario")]
        public IEnumerable<Galeria> FindByUsuario(int idUsuario)
        {
            return _galeriaRepositorio.FindByUsuario(idUsuario);
        }

        [HttpPost]
        [Route("UploadArquivos")]
        [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
        public IEnumerable<Galeria> UploadArquivos(Galeria fotos)
        {

            //if (!(String.IsNullOrEmpty(fotos.Foto)) && fotos != null)
            //{
            //
            //    Galeria galeria = new Galeria();
            //    galeria.IdUsuario = fotos.IdUsuario;
            //    galeria.NumCode = fotos.NumCode;
            //    galeria.Geolocalizacao = fotos.Geolocalizacao;
            //    galeria.FotoDescricao = fotos.FotoDescricao;
            //
            //    string dateTime = DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss");
            //    string extensao = fotos.FotoNome.Split('.')[1];
            //    string caminho = "C:/Base/" + galeria.IdUsuario.ToString() + "/Galeria/" + dateTime + "." + extensao;
            //    System.IO.File.WriteAllBytes(caminho, Convert.FromBase64String(fotos.Foto));
            //    galeria.FotoNome = dateTime;
            //    galeria.Caminho = caminho;
            //    _galeriaRepositorio.Add(galeria);
            //}
            //
            return _galeriaRepositorio.FindByUsuario(fotos.IdUsuario);
        }

        [HttpGet("{id}", Name = "GetUsuarioFotos")]
        public IActionResult IEnumerable<Galeria>(int id)
        {
            var usuario = _galeriaRepositorio.Find(id);
            if (usuario == null)
                return NotFound();

            return new ObjectResult(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _galeriaRepositorio.Find(id);

            if (usuario == null)
                return NotFound();

            _galeriaRepositorio.Remove(id);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAll(int idUsuario)
        {
            var galeria = _galeriaRepositorio.FindByUsuario(idUsuario);

            if (galeria == null)
                return NotFound();

            _galeriaRepositorio.RemoveAll(idUsuario);

            return new NoContentResult();
        }

    }
}