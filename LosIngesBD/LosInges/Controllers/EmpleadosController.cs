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
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        //
        private LosIngesEntities db = new LosIngesEntities();
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.ListEmp = ListaEmpleado_Result.ToList();
            //ViewBag.ListEmp = (from LE in db.Empleado
            //                   join d in db.Departamento on LE.IdDepartamento equals d.IdDepartamento
            //                   join P in db.Puesto on LE.IdPuesto equals P.IdPuesto
            //                   select new
            //                   {
            //                       IdEmp = LE.IdEmpleado,
            //                       NomEmp = LE.Nombre,
            //                       ApPat = LE.ApPat,
            //                       ApMat = LE.ApMat,
            //                       DepaEmp = d.Descripcion,
            //                       PuestoEmp = P.Descripcion
            //                   }).ToList();

            ViewBag.ListPues = (from LP in db.Puesto
                                select new
                                {
                                    IdPues = LP.IdPuesto,
                                    DesPues = LP.Descripcion

                                }).ToList();

            ViewBag.ListDepa = (from LD in db.Departamento
                                select new
                                {
                                    IdDepa = LD.IdDepartamento,
                                    DesDepa = LD.Descripcion

                                }).ToList();
            return View("Empleado");
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(Empleado Emp)
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
                    db.Alta_Empleado(Emp.Nombre, Emp.ApMat,Emp.ApPat,Emp.IdDepartamento, Emp.IdPuesto);
                    return RedirectToAction("Create", "Empleado");
                }

            }
            catch
            {
                return View("Create");
            }

        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
