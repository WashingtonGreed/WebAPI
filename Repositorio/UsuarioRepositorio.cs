using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IRepositorio;
using WebAPI.Models;

namespace WebAPI.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly CobaiaContext _context;

        public UsuarioRepositorio(CobaiaContext ctx)
        {
            _context = ctx;
        }
        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario FindByEmailSenha(string email, string senha)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email==email && u.Senha==senha);
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public Usuario Find(int id)
        {
            return _context.Usuario.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public void Remove(int id)
        {
            var entity = _context.Usuario.First(u => u.Id == id);
            _context.Usuario.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.SaveChanges();
        }
    }
}
