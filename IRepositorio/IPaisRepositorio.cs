using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IRepositorio
{
    public interface IPaisRepositorio
    {
        void Add(Pais pais);

        IEnumerable<Pais> GetAll();

        Pais Find(int id);

        void Remove(int id);

        void Update(Pais pai);
    }
}
