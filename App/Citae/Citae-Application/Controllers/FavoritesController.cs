using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citae_Application.Controllers
{
    public class FavoritesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Favoritos";
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}