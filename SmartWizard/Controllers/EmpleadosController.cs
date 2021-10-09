using Microsoft.AspNetCore.Mvc;
using SmartWizard.Entities;
using SmartWizard.Models;
using SmartWizard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWizard.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDBContext context;

        public EmpleadosController(ApplicationDBContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return View("PersonalInfo");
        }
        private Empleado GetEmpleado()
        {
            if (HttpContext.Session.GetObject<Empleado>("DataObject") == null)
            {
                HttpContext.Session.SetObject("DataObject", new Empleado());
            }
            return (Empleado)HttpContext.Session.GetObject<Empleado>("DataObject");
        }
        private void RemoveEmpleado()
        {
            HttpContext.Session.SetObject("DataObject", null);
        }
        [HttpPost]
        public ActionResult PersonalInfo(EmpleadoPersonalViewModel personal, string BtnPrevious, string BtnNext)
        {
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    Empleado empleado = GetEmpleado();
                    empleado.Nombres = personal.Nombres;
                    empleado.Apellidos = personal.Apellidos;
                    empleado.Domicilio = personal.Domicilio;

                    HttpContext.Session.SetObject("DataObject", empleado);

                    return View("LaboralInfo");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult LaboralInfo(EmpleadoLaboralViewModel laboral, string BtnPrevious, string BtnNext, string BtnCancel)
        {
            Empleado empleado = GetEmpleado();

            if (BtnPrevious != null)
            {
                EmpleadoPersonalViewModel info = new EmpleadoPersonalViewModel();
                info.Nombres = empleado.Nombres;
                info.Apellidos = empleado.Apellidos;
                info.Domicilio = empleado.Domicilio;

                return View("PersonalInfo", info);
            }
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    empleado.Departamento = laboral.Departamento;
                    empleado.FechaIngreso = laboral.FechaIngreso;
                    empleado.Salario = laboral.Salario;
                    
                    context.Empleados.Add(empleado);
                    context.SaveChanges();
                    RemoveEmpleado();

                    return View("Completado");
                }
            }
            if (BtnCancel != null)
                RemoveEmpleado();
            return View();
        }
    }
}
