using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Pais
    {
        public int Id { get; set; }
        public string NamePt { get; set; }
        public string NameEn { get; set; }
        public string NameEs { get; set; }
        public int NumCode { get; set; }
        public string Iso { get; set; }
        public string Iso3 { get; set; }
    }
}
