using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LosInges.Models;
using Syncfusion.EJ2.Navigations;
using Newtonsoft.Json;

namespace LosInges.Controllers
{
    
    public class ClienteController : Controller
    {
        private LosIngesEntities db = new LosIngesEntities();
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.TipoCliente = (from TP in db.TipoCliente select new 
            {
                IdTP=TP.IdTipoCliente,
                Des=TP.Descripcion
            }).ToList();
            return View("Cliente");
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View("Create");
                }
                else
                {
                    //ObjectParameter OutPut = new ObjectParameter("Correcto", typeof(bool));
                    db.SP_Cliente_Alta(model.Nombre,model.ApPat,model.ApMat,model.Telefono,model.Correo);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Update(int IdCliente)
        {
            Cliente cliente = db.Cliente.Where(x => x.IdCliente == IdCliente).FirstOrDefault<Cliente>();
            
            ViewBag.TipoCliente = cliente.IdTipoCliente;
            //Cliente Cl =(from C in db.Cliente where C.IdCliente == IdCliente select new Cliente
            //{
            //    IdCliente=C.IdCliente,
            //    Nombre=C.Nombre,
            //    ApPat=C.ApPat,
            //    ApMat=C.ApMat,
            //    Telefono=C.Telefono,
            //    Correo=C.Correo,
            //    IdTipoCliente=C.IdTipoCliente

            //}).FirstOrDefault();
            return View("Update", cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Update(Cliente model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View("Update");
                }
                else
                {
                    //ObjectParameter OutPut = new ObjectParameter("Correcto", typeof(bool));
                    db.SP_Cliente_Update(model.IdCliente,model.Nombre, model.ApPat, model.ApMat, model.Telefono, model.Correo);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch
            {
                return View("Update");
            }
        }

    }
}
