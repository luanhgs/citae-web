using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citae_Application.Controllers
{
    public class AuthorsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Autores";
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

    }
}