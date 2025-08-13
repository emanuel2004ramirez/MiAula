using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class CalificacionController : Controller
    {
        // GET: CalificacionController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexSeccion(string grado)
        {
            return View((object)grado);
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult IndexSeccion2(string grado)
        {
            return View((object)grado);
        }

        public ActionResult SeleccionarMateria2(string grado, string seccion)
        {
            return View(ClaseAPI.ClaseConPlanificacion(grado, seccion));
        }

        // GET: PlanificacionController/Details/5
        public ActionResult SeleccionarMateria(string grado, string seccion)
        {
            return View(ClaseAPI.ClaseConPlanificacion(grado,seccion));
        }

        public ActionResult Seleccionar_Alumno(int id_clase)
        {

            Calificar_Lista_Alumno_id_Clase e = new Calificar_Lista_Alumno_id_Clase();

            e.alumnos = ClaseAPI.Alumnos_EN_CLASE(id_clase);
            e.id_clase = id_clase;

            return View(e);
        }

        public ActionResult Ver_Tareas(int id_clase,int id_alumno)
        {
            Calificar_Lista_Alumno_id_Clase e = new Calificar_Lista_Alumno_id_Clase();

            e.tareas = TareaAPI.GetTarea_ByID(id_clase);
            e.id_clase = id_clase;
            e.alumno = AlumnoAPI.get_Alumno(id_alumno);
            e.examen = TareaAPI.Get_ExamenBY_IDCLASE(id_clase);
            return View(e);
        }

        

        // GET: CalificacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalificacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalificacionController/Create
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

        // GET: CalificacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalificacionController/Edit/5
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

        // GET: CalificacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalificacionController/Delete/5
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
