using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Citae_Application.Models;
using Citae_Application.DAL;

namespace Citae_Application.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            if(Session["UsuarioLogado"] != null)
            {
                ViewBag.Title = $"Olá, {(Session["UsuarioLogado"] as Usuario).nome}";
                ViewBag.User = Session["UsuarioLogado"];
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
            
        }

        public ActionResult Signin()
        {
            if (Session["UsuarioLogado"] != null)
                return RedirectToAction("Index", "Home");
            else {
                ViewBag.Title = "Junte-se a nós !!";
                return View();
            }
        }

        //Cadastro do Usuário
        [HttpPost]
        public ActionResult Signin(string nome, string email, string senha)
        {
            string error = null;
            DALUsuario DALUser = new DALUsuario();
            Usuario user = new Usuario(nome, email, senha);

            //cadastro deu certo
            if (DALUser.Insert(user, ref error)) {

                Session["UsuarioLogado"] = user; //sessão para manter o login do usuário
                return RedirectToAction("Index", "Home");
            }
            //cadastro não deu certo
            else {
                ViewBag.ErrorSignin = error;
                return View();
            }
        }

        public ActionResult Login()
        {
            if (Session["UsuarioLogado"] != null)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.Title = "Entre em sua conta !";
                return View();
            }

        }

        //Login do Usuário
        [HttpPost]
        public ActionResult Login(string email, string senha)
        {
            string error = null;
            DALUsuario DALUser = new DALUsuario();
            Usuario user = new Usuario(email, senha);

            //cadastro deu certo
            if (DALUser.Login(user, ref error)) {
                Session["UsuarioLogado"] = DALUser.Select(user); //sessão para manter o login do usuário
                return RedirectToAction("Index", "Home");
            }
            //cadastro não deu certo
            else {
                ViewBag.ErrorLogin = error;
                return View();
            }
        }

    }
}