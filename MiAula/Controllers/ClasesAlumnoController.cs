using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class ClasesAlumnoController : Controller
    {
        // GET: ClasesAlumnoController
        public ActionResult IndexSeccion()
        {
            return View();
        }

        // GET: ClasesAlumnoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClasesAlumnoController/Create
        public ActionResult Create(string seccion,string Grado)
        {
            Listas Listas = new Listas();
            Listas.Alumnos = ClasesAlumnoAPI.AlumnoNoTieneClases(seccion, Grado);
            Listas.Clases = ClaseAPI.get_Clases_bySeccionGrado(seccion,Grado);
            
            return View(Listas);
        }

        // POST: ClasesAlumnoController/Create

        [HttpPost]
        public ActionResult Create(int idAlumno, List<int> idClases)
        {
            
                if (idClases == null || idClases.Count == 0)
            {
                // Redirige a una página de error si no se seleccionó ninguna clase
                return RedirectToAction("FAILED", "MSG");
            }

            if (ClasesAlumnoAPI.AsignarClases_Alumno(idAlumno, idClases))
            {
                return RedirectToAction("SUCCESS", "MSG");
            }
            else
            {
                return RedirectToAction("FAILED", "MSG");
            }
        }
        // GET: ClasesAlumnoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClasesAlumnoController/Edit/5
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

        // GET: ClasesAlumnoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClasesAlumnoController/Delete/5
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





        public ActionResult indexGrado(string seccion)
        {

            

           
            return View((object)seccion);
        }
    }
}
