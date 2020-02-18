using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LosInges.Models;

namespace LosInges.Controllers
{
    public class HomeController : Controller
    {
        private LosIngesEntities db = new LosIngesEntities();
        public ActionResult Index()
        {
            ViewBag.ListaCliente = (from lc in db.Cliente select new { 
                IdCliente=lc.IdCliente,
                Nombre=lc.Nombre,
                appat=lc.ApPat,
                apmat=lc.ApMat,
                tel=lc.Telefono,
                correo=lc.Correo
            }).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}