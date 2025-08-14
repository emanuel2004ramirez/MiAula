using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class AsistenciaController : Controller
    {
        
        public ActionResult Estadistica(int alumnoId = 0)
        {
            // Cargar lista de alumnos para el dropdown
            var listaAlumnos = AlumnoAPI.getAll(); // Tu método para traer alumnos

            ViewBag.ListaAlumnos = listaAlumnos;

            EstadisticaAlumno estadisticas = null;
            if (alumnoId != 0)
            {
                estadisticas = AsistenciaAPI.get_Estadisticas(alumnoId); // Llama al método anterior
                ViewBag.Estadisticas = estadisticas;

                var alumno = listaAlumnos.FirstOrDefault(a => a.Id == alumnoId);
                ViewBag.AlumnoNombre = alumno != null ? alumno.Nombre : "";
            }

            return View();
        }
      
        // GET: AsistenciaController
        public ActionResult Index()
        {
            return View(AlumnoAPI.getAll());
        }

        // GET: AsistenciaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AsistenciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_Asistencia(int AlumnoId, string Estado)
        {

            if (AsistenciaAPI.Create_Asistencia(AlumnoId, Estado))
            {

                return RedirectToAction("Index", "Asistencia");
            }
            else
            {
                return RedirectToAction("FAILED", "MSG");
            }
        }

        // POST: AsistenciaController/Create
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

        // GET: AsistenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AsistenciaController/Edit/5
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

        // GET: AsistenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AsistenciaController/Delete/5
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
