using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        void Add(Usuario usuario);

        IEnumerable<Usuario> GetAll();

        Usuario FindByEmailSenha(string email, string senha);

        Usuario FindByEmail(string email);

        Usuario Find(int id);

        void Remove(int id);

        void Update(Usuario user);
    }
}
