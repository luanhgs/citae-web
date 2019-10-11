﻿using System;
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
            string error = null;
            DALUsuario DALUser = new DALUsuario();

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

        //Login do Usuário
        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            string error = null;
            DALUsuario DALUser = new DALUsuario();

            //cadastro deu certo
            if (DALUser.Login(user, ref error))
            {
                Session["UsuarioLogado"] = DALUser.Select(user); //sessão para manter o login do usuário
                return RedirectToAction("Index", "Home");
            }
            //cadastro não deu certo
            else
            {
                ViewBag.ErrorLogin = error;
                return View();
            }
        }
    }
}