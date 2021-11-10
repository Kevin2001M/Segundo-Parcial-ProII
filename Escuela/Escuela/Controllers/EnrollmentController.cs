using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
    public class EnrollmentController : Controller
    {
        private readonly ILogger<EnrollmentController> _logger;
        private IRollements irollements;
        private IStudent istudent;
        private ICourse icourse;

        public EnrollmentController(ILogger<EnrollmentController> logger, IRollements irollements, IStudent istudent, ICourse icourse)
        {
            this.irollements = irollements;
            this.istudent = istudent;
            this.icourse = icourse;
            _logger = logger;
        }


        public IActionResult Enrollment()
        {
            var listado = irollements.UnionDeTablas();
            return View(listado);
        }


        public IActionResult Create(Enrollment e)
        {
            var informationOfCoboBox = icourse.ListarCursos();
            var informationOfCoboBoxForStudent = istudent.ListaEstudiantes();

            List<SelectListItem> listCourse = new List<SelectListItem>();
            List<SelectListItem> ListStudent = new List<SelectListItem>();

            //Course
            foreach (var iteracion in informationOfCoboBox)
            {
                listCourse.Add(
                    new SelectListItem
                    {
                        Text = iteracion.Title,
                        Value = Convert.ToString(iteracion.CouserId)
                    }
                    );

                ViewBag.estadoListCourse = listCourse;
            }


            //Students
            foreach (var iteracion in informationOfCoboBoxForStudent)
            {
                ListStudent.Add(
                    new SelectListItem
                    {
                        Text = iteracion.FirstMidName,
                        Value = Convert.ToString(iteracion.StudentId)
                    }
                    );

                ViewBag.estadoListStudent = ListStudent;
            }
            return View();

        }


        public IActionResult getInformationCombobox(Enrollment e)
        {

            if (ModelState.IsValid)
            {
                irollements.Insertar(e);
                TempData["mensaje"] = "El enrollment se ha guardado";
                return RedirectToAction("Enrollment");
            }
            return View("Create");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
