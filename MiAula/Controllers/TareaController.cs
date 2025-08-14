using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace MiAula.Controllers
{
    public class TareaController : Controller
    {
        // GET: TareaController
        public ActionResult Index(string tema , int id_clase)
        {
            
            return View(TareaAPI.GetTarea_By_Materia_ID(tema,id_clase));
        }

      
        // GET: TareaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TareaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TareaController/Create
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

        // GET: TareaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TareaController/Edit/5
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

        // GET: TareaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TareaController/Delete/5
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
