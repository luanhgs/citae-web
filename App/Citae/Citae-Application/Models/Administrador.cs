using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citae_Application.Models
{
    public class Administrador
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public byte[] imgPerfil { get; set; }
        public string CPF { get; set; }
    }
}