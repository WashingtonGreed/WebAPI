using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IRepositorio;
using WebAPI.Models;

namespace WebAPI.Repositorio
{
    public class PaisRepositorio : IPaisRepositorio
    {

        private readonly CobaiaContext _context;

        public PaisRepositorio(CobaiaContext ctx)
        {
            _context = ctx;
        }
        public void Add(Pais pais)
        {
            _context.Pais.Add(pais);
            _context.SaveChanges();
        }

        public Pais Find(int numCode)
        {
            return _context.Pais.FirstOrDefault(u => u.NumCode == numCode);
        }

        public IEnumerable<Pais> GetAll()
        {
            return _context.Pais.ToList();
        }

        public void Remove(int numCode)
        {
            var entity = _context.Pais.First(u => u.NumCode == numCode);
            _context.Pais.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Pais pais)
        {
            _context.Pais.Update(pais);
            _context.SaveChanges();
        }
    }
}
