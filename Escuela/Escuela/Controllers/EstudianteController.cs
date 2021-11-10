using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Dominio;
using Escuela.Migrations;
using Escuela.Models;
using Escuela.Repositorio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;


namespace Escuela.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly ILogger<EstudianteController> _logger;
        private IStudent istudent;

        public EstudianteController(ILogger<EstudianteController> logger, IStudent istudent)
        {
            this.istudent = istudent;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Estudiante()
        {
            var listado = istudent.ListaEstudiantes();
            return View(listado);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Students s)
        {

            if (ModelState.IsValid)
            {
                istudent.Insertar(s);
                TempData["mensaje"] = "El estudiante se ha guardado";
                return RedirectToAction("Estudiante");

            }
            else
            { 
                return View("Create");
            }
        }


        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,LastName,FirstMidName,EnrollmentDate")] Students s)
        {
            if (!ModelState.IsValid)
            {
                return View(s);
            }
            istudent.Update(id, s);
            return RedirectToAction("Estudiante");

        }
        public IActionResult UpdateEdit()
        {

            return View("Update");
        }



       

    }
}
