using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class ObservacionController : Controller
    {
        // GET: ObservacionController
        public ActionResult Index()
        {
            // Traer lista de alumnos para el dropdown
            var listaAlumnos = AlumnoAPI.getAll();
            ViewBag.ListaAlumnos = listaAlumnos;
            return View();
        }



        [HttpPost]
        public ActionResult Crear(int ObservacionId, int AlumnoId, string Tipo, string Comentario)
        {
            bool exito = ObservacionAPI.CrearObservacion( ObservacionId,  AlumnoId, Tipo,  Comentario);

            if (exito)
                return RedirectToAction("SUCCESS", "MSG");
            else
                return RedirectToAction("FAILED", "MSG");
        }
        public ActionResult Crear()
        {
          

            return View();
        }


        public ActionResult PorAlumno(int alumnoId = 0)
        {
            // Obtener la lista de alumnos para el dropdown
            var listaAlumnos = AlumnoAPI.getAll(); // Tu método para traer todos los alumnos
            ViewBag.ListaAlumnos = listaAlumnos;

            // Si no se ha seleccionado ningún alumno, no mostramos nada
            List<Observacion> observaciones = null;
            if (alumnoId != 0)
            {
                observaciones = ObservacionAPI.GetObservacionesPorAlumno(alumnoId);
                ViewBag.AlumnoSeleccionado = alumnoId;
            }

            return View(observaciones);
        }

        // GET: ObservacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ObservacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ObservacionController/Create
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

        // GET: ObservacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ObservacionController/Edit/5
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

        // GET: ObservacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ObservacionController/Delete/5
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
