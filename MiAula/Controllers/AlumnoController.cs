using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: AlumnoController
        public ActionResult Index()
        {
            return View(AlumnoAPI.getAll());
        }

        // GET: AlumnoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlumnoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlumnoController/Create
        [HttpPost]
        public ActionResult Create(string Nombre, string Apellido, string Fecha_Nacimiento, string Grado, string Seccion)
        {

            if (AlumnoAPI.Create_Alumno(Nombre, Apellido, Fecha_Nacimiento, Grado, Seccion))
            {

                return RedirectToAction("SUCCESS", "MSG");
            }
            else
            {
                return RedirectToAction("FAILED", "MSG");
            }
        }

        public ActionResult Buscar_Alumno()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Buscar_AlumnoP(int id)
        {

            if (AlumnoAPI.buscar(id) != null)
            {
                return View(AlumnoAPI.buscar(id));

            }

            return RedirectToAction("FAILED_SEARCH","MSG");
        }
        // GET: AlumnoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(AlumnoAPI.buscar(id));
        }

        // POST: AlumnoController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string Nombre, string Apellido,string Fecha_Nacimiento,string Grado,string Seccion)
        {
           if (AlumnoAPI.Edit_Alumno(id,Nombre,Apellido,Fecha_Nacimiento,Grado,Seccion))
            {
                return RedirectToAction("SUCCESS_EDIT", "MSG");

            }

            return RedirectToAction("FAILED_EDIT", "MSG");
        }

        // GET: AlumnoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(AlumnoAPI.buscar(id));
        }

        // POST: AlumnoController/Delete/5
        [HttpPost]

        public ActionResult Delete(int id,IFormCollection collection)
        {
            if (AlumnoAPI.Delete_Alumno(id))
            {

                return RedirectToAction("SUCCESS_DELETE","MSG");
            }

            return RedirectToAction("FAILED_DELETE", "MSG");
        }
    }
}
