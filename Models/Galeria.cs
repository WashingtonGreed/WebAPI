using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Galeria
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Caminho { get; set; }
        public string FotoNome { get; set; }
        public int? NumCode { get; set; }
        public string Geolocalizacao { get; set; }
        public string FotoDescricao { get; set; }
        public string Foto { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool FotoPerfil { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
