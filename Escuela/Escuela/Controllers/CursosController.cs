using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Escuela.Controllers
{
    public class CursosController : Controller
    {

        private readonly ILogger<CursosController> _logger;
        private ICourse icourse;

        public CursosController(ILogger<CursosController> logger, ICourse icourse)
        {
            this.icourse = icourse;
            _logger = logger;
        }


        public IActionResult Cursos()
        {
            var listado = icourse.ListarCursos();
            return View(listado);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course c)
        {
            icourse.Insertar(c);
            TempData["mensaje"] = "El curso se ha guardado";
            return RedirectToAction("Cursos");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,Title,Credits")] Course c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }
            icourse.Update(id, c);
            return RedirectToAction("Cursos");

        }
        public IActionResult UpdateEdit()
        {

            return View("Update");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
