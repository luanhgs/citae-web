using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citae_Application.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public byte[] imgPerfil { get; set; }

        public Usuario(int idUsuario, string nome, string email, string senha, byte[] imgPerfil) {
            this.idUsuario = idUsuario;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.imgPerfil = imgPerfil;
        }

        public Usuario(int idUsuario, string nome, string email, string senha)
        {
            this.idUsuario = idUsuario;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }

        public Usuario(string email, string senha) {
            this.email = email;
            this.senha = senha;
        }

        public Usuario(string nome, string email, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }
    }
}