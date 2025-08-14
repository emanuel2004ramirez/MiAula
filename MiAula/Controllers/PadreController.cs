using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class PadreController : Controller
    {
        // GET: PadreController
        public ActionResult Index()
        {
            var listaAlumnos = AlumnoAPI.getAll();
            ViewBag.ListaAlumnos = listaAlumnos;
            return View();

            return View();
        }

        public ActionResult PorAlumno(int alumnoId = 0)
        {
            // Obtener lista de alumnos para el dropdown
            var listaAlumnos = AlumnoAPI.getAll();
            ViewBag.ListaAlumnos = listaAlumnos;

            List<Padre> padres = new List<Padre>();

            // Si se seleccionó un alumno, obtenemos sus padres
            if (alumnoId != 0)
            {
                padres = PadreAPI.GetPadresPorAlumno(alumnoId);
                ViewBag.AlumnoSeleccionado = alumnoId;
            }

            return View(padres);
        }

        // GET: PadreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(int padreId, int alumnoId, string nombre, string apellido, string relacion, string telefono, string correo)
        {
            var ListaAlumnos = AlumnoAPI.getAll();
            ViewBag.ListaAlumnos = ListaAlumnos;
            bool exito = PadreAPI.CrearPadre(padreId, alumnoId, nombre, apellido, relacion, telefono, correo);

            if (exito)
                return RedirectToAction("SUCCESS", "MSG");
            else
                return RedirectToAction("FAILED", "MSG");
        }
        public ActionResult Crear()
        {
            var listaAlumnos = AlumnoAPI.getAll();
            ViewBag.ListaAlumnos = listaAlumnos;
            return View();
        }

        // GET: PadreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PadreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PadreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PadreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PadreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PadreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
