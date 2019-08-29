using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citae_Application.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dados do Usuário";
            return View();
        }
    }
}