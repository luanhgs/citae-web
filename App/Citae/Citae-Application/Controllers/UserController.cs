using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Citae_Application.Models;

namespace Citae_Application.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dados do Usuário";
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Entre em sua conta !";
            return View();
        }
        public ActionResult Signin()
        {
            ViewBag.Title = "Junte-se a nós !!";
            return View();
        }

        //Cadastro do Usuário
        [HttpPost]
        public ActionResult Signin(Usuario user)
        {
            return View();
        }
    }
}