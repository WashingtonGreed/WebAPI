using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IRepositorio
{
    public interface IGaleriaRepositorio
    {
        void Add(Galeria galeria);

        IEnumerable<Galeria> GetAll();

        Galeria Find(int id);

        IEnumerable<Galeria> FindByUsuario(int idUsuario);

        void Remove(int id);

        void RemoveAll(int idUsuario);

     }
}
