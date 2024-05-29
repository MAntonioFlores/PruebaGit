using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EquiposController : Controller
    {
        // GET: Equipos
        public ActionResult GetAll()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form()
        {
            return View();
        }
    }
}