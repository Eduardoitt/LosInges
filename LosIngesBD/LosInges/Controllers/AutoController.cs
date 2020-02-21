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
    public class AutoController : Controller
    {
        private LosIngesEntities db = new LosIngesEntities();
        // GET: Auto
        public ActionResult ListaCarro(int IdCliente)
        {
            Session["IdCliente"] = IdCliente;

            ViewBag.IdCliente = Session["IdCliente"];

            ViewBag.LA = (from a in db.Auto
                          where a.IdCliente == IdCliente
                          select new
                          {
                              IdAuto = a.IdAuto,
                              Placa = a.Placa,
                              Marca = a.Marca,
                              Modelo = a.Modelo,
                              Anio = a.Anio,
                              IdCliente = a.IdCliente
                          }).ToList();

            return View("ListaAutos");
        }

        // GET: Auto/Details/5
        [HttpGet]
        public ActionResult AddServicio(int IdCliente)
        {
            //int IdClient = Convert.ToInt32(Session["IdCliente"]);
            ViewBag.LAu = (from a in db.Auto
                           where a.IdCliente == IdCliente
                           select new
                           {
                               IdAuto = a.IdAuto,
                               Carro =a.Marca+" "+ a.Modelo
                           }).ToList();
            ViewBag.Emp = (from e in db.Empleado
                           where e.IdDepartamento != 7
                           select new
                           {
                               IdEmpleado = e.IdEmpleado,
                               Nom = e.Nombre + " " + e.ApPat
                           }).ToList();
            ViewBag.Dep = (from d in db.Departamento
                           where d.IdDepartamento != 7
                           select new
                           {
                               IdD=d.IdDepartamento,
                               Nombre=d.Descripcion
                           }).ToList();
            ViewBag.Prod = (from p in db.Producto
                           select new
                           {
                               IdP = p.IdProducto,
                               Nombre = p.Descripcion
                           }).ToList();
            return View("ServicioAuto");
        }
        [HttpPost]
        public ActionResult AddServicio(Restauracion model)
        {
            int IdCliente = Convert.ToInt32(Session["IdCliente"]);
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View("ServicioAuto");
                }
                else
                {
                    //ObjectParameter OutPut = new ObjectParameter("Correcto", typeof(bool));
                     db.SP_AutoRestauracion_Alta(model.IdAuto,model.IdEmpleado,model.IdDepartamento,model.Descripcion,model.PrecioRestauracion,model.IdProducto);
                    return RedirectToAction("Update", "Cliente", new { IdCliente = IdCliente });
                    
                }
            }
            catch
            {
                return View("ServicioAuto");
            }
        }

        // GET: Auto/Create
        [HttpGet]
        public ActionResult Create(int IdCliente)
        {
            return View("AutoCreate");
        }

        // POST: Auto/Create
        [HttpPost]
        public ActionResult Create(Auto model)
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
                    db.SP_Auto_Alta(model.Placa, model.Marca, model.Modelo, model.Anio, model.IdCliente);
                    return RedirectToAction("Update", "Cliente", new { IdCliente = model.IdCliente });
                }
            }
            catch
            {
                return View("Update");
            }
        }


    }
}
