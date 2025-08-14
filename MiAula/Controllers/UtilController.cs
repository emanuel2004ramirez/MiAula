using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class UtilController : Controller
    {
        // GET: UtilController
        public ActionResult Index()
        {
            var listaClases = ClaseAPI.getAll(); // Este método debe retornar List<Clase>
            ViewBag.ListaClases = listaClases;

            return View();
        }


        public ActionResult Estadisticas(int claseId = 0)
        {
            // Cargar clases para el select
            var listaClases = ClaseAPI.getAll(); // tu método para traer clases
            ViewBag.ListaClases = listaClases;
            ViewBag.ClaseSeleccionada = claseId;

            List<UtilEstadistica> estadisticas = new List<UtilEstadistica>();

            if (claseId != 0)
            {
                estadisticas = UtilAPI.GetEstadisticas(claseId);
            }

            return View(estadisticas);
        }

        public ActionResult PorMateria(int materiaId = 0)
        {
            // Cargar lista de materias para el select
            var listaMaterias = ClaseAPI.getAll(); // obtener materias
            ViewBag.ListaMaterias = listaMaterias;
            ViewBag.MateriaSeleccionada = materiaId;

            List<Util> utiles = new List<Util>();

            if (materiaId != 0)
            {
                utiles = UtilAPI.GetUtilesPorMateria(materiaId);
            }

            return View(utiles);
        }


        // POST: /Util/Crear
        [HttpPost]
        public IActionResult Crear(int claseId, string nombre, bool obligatorio)
        {
            var listaClases = ClaseAPI.getAll(); // Este método debe retornar List<Clase>
            ViewBag.ListaClases = listaClases;
            bool exito = UtilAPI.Create_Util(claseId, nombre, obligatorio);

            if (exito)
                return RedirectToAction("SUCCESS", "MSG"); // Redirige a tu vista de éxito
            else
                return RedirectToAction("FAILED", "MSG");  // Redirige a tu vista de fallo
        }

        // GET: UtilController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UtilController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilController/Create
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

        // GET: UtilController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UtilController/Edit/5
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

        // GET: UtilController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UtilController/Delete/5
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
