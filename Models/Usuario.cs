using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Galeria = new HashSet<Galeria>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public bool? Sexo { get; set; }
        public int? Pais { get; set; }
        public string Geolocalizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Token { get; set; }
        public DateTime? DataNascimento { get; set; }

        public virtual ICollection<Galeria> Galeria { get; set; }
    }
}
