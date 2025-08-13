using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class ClasesController : Controller
    {
        // GET: ClasesController
        public ActionResult Index()
        {

            return View(ClaseAPI.getAll());
        }

        // GET: ClasesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClasesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClasesController/Create
        [HttpPost]
        public ActionResult Create(string Nombre , string Grado,string Seccion,string Horario)
        {
            ClaseAPI.Create_Clase(Nombre,Grado,Seccion,Horario);
            return RedirectToAction("index","Home");
        }

        // GET: ClasesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ClaseAPI.get_Clase(id));
        }

        // POST: ClasesController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string Nombre, string Grado, string Seccion,string Horario)
        {
            ClaseAPI.Edit_Clase(id, Nombre, Grado, Seccion, Horario);
            return RedirectToAction(nameof(Index));
        }

        // GET: ClasesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ClaseAPI.get_Clase(id));
        }

        // POST: ClasesController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ClaseAPI.Delete_Clase(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Alumnos_EN_CLASE(int id)
        {
            return View(ClaseAPI.Alumnos_EN_CLASE(id));
        }
    }
}
