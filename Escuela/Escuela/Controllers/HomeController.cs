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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourse icourse;
        private IRollements irollements;
        private IStudent istudent;

        public HomeController(ILogger<HomeController> logger, ICourse icourses, IRollements irollements, IStudent istudent)
        {
            this.icourse = icourses;
            this.irollements = irollements;
            this.istudent = istudent;
            _logger = logger;
        }


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Tabla()
        {
            var listado = irollements.UnionDeTablas();
            

            return View(listado);
        }

        public IActionResult GetAllForJoinJsonLinq()
        {
            var listado = irollements.UnionDeTablas();

            var CombinacionDeArreglos = (from union in listado
                                         select new
                                         {

                                             union.Course.Title,
                                             union.Students.LastName,
                                             union.Students.FirstMidName,
                                             union.Grade
                                         }).ToList();

            return Json (new { CombinacionDeArreglos });
        }

        public IActionResult ComboBox(Enrollment e)
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

            irollements.Insertar(e);
            return RedirectToAction("Enrollment");

            
        }


        public IActionResult getInformationCombobox(Enrollment e)
        {

            return RedirectToAction("Index");
        }


        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();


            return Json(new { data = DandoFormatoJson });
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
