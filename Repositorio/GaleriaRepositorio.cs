using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IRepositorio;
using WebAPI.Models;

namespace WebAPI.Repositorio
{
    public class GaleriaRepositorio : IGaleriaRepositorio
    {

        private readonly CobaiaContext _context;

        public GaleriaRepositorio(CobaiaContext ctx)
        {
            _context = ctx;
        }
        public void Add(Galeria galeria)
        {
            _context.Galeria.Add(galeria);
            _context.SaveChanges();
        }

        public Galeria Find(int id)
        {
            return _context.Galeria.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Galeria> FindByUsuario(int id)
        {
            return _context.Galeria.ToList().Where(u => u.IdUsuario == id);
        }

        public IEnumerable<Galeria> GetAll()
        {
            return _context.Galeria.ToList();
        }

        public void Remove(int id)
        {
            var entity = _context.Galeria.First(u => u.Id == id);
            _context.Galeria.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveAll(int idUsuario)
        {
            IEnumerable<Galeria> entity = _context.Galeria.ToList().Where(u => u.IdUsuario == idUsuario);
            _context.Galeria.RemoveRange(entity);
            _context.SaveChanges();
        }


    }
}
