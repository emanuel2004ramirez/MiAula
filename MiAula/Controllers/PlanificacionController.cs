using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MiAula.Controllers
{

    public class PlanificacionController : Controller
    {
        // GET: PlanificacionController
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
            return View(ClaseAPI.ClaseConPlanificacion(grado,seccion));
        }

        // GET: PlanificacionController/Details/5
        public ActionResult SeleccionarMateria(string grado, string seccion)
        {
            return View(ClaseAPI.ClaseSinPlanificacion(grado,seccion));
        }

        public ActionResult VerTarea(int id, string grado, string seccion)
        {
            VerTareaC ver = new VerTareaC();
            ver.Clase = ClaseAPI.get_Clase(id);
            ver.Tareas = PlanificacionAPI.Planificacion(grado, seccion);
            
            return View(ver);
        }


        // GET: PlanificacionController/Create
        public ActionResult Create(int id)
        {
            
            return View(ClaseAPI.get_Clase(id));
        }

        // POST: PlanificacionController/Create
        [HttpPost]

        public ActionResult Create(IFormCollection collection, int id)
        {
            try
            {
                var temas = new List<Tema>();

                // Validar y obtener datos básicos
                var fechainicio = collection["FechaInicio"];
                var fechafin = collection["FechaFin"];

                if (!int.TryParse(collection["PorcentajeTareas"], out int porcentaje_tareas) ||
                    !int.TryParse(collection["PorcentajeExamenes"], out int porcentaje_examenes))
                {
                    ModelState.AddModelError("", "Los porcentajes deben ser valores numéricos válidos.");
                    return View();
                }

                int totalTemas = 0;
                while (!string.IsNullOrEmpty(collection[$"temas[{totalTemas}].Nombre"]))
                {
                    totalTemas++;
                }

                Console.WriteLine($"=== PROCESANDO {totalTemas} TEMAS ===");

                for (int temaIndex = 0; temaIndex < totalTemas; temaIndex++)
                {
                    string nombreTema = collection[$"temas[{temaIndex}].Nombre"];
                    string objetivosTema = collection[$"temas[{temaIndex}].Objetivos"];

                    int totalTareasDelTema = 0;
                    while (!string.IsNullOrEmpty(collection[$"temas[{temaIndex}].Tareas[{totalTareasDelTema}].Descripcion"]))
                    {
                        totalTareasDelTema++;
                    }

                    Console.WriteLine($"Procesando Tema[{temaIndex}]: '{nombreTema}' - tiene {totalTareasDelTema} tareas");

                    // --- CORRECCIÓN CLAVE AQUÍ ---
                    // Solo procesamos y agregamos el tema si tiene al menos una tarea
                    if (totalTareasDelTema > 0)
                    {
                        for (int tareaIndex = 0; tareaIndex < totalTareasDelTema; tareaIndex++)
                        {
                            string descripcionTarea = collection[$"temas[{temaIndex}].Tareas[{tareaIndex}].Descripcion"];
                            string tipoTarea = collection[$"temas[{temaIndex}].Tareas[{tareaIndex}].Tipo"];
                            // CORRECCIÓN: El nombre del campo en HTML es 'Fecha_Entrega'
                            string fechaLimiteTarea = collection[$"temas[{temaIndex}].Tareas[{tareaIndex}].Fecha_Entrega"];

                            var tema = new Tema(
                                nombreTema,
                                objetivosTema,
                                id,
                                descripcionTarea,
                                tipoTarea,
                                fechaLimiteTarea,
                                fechainicio,
                                fechafin,
                                porcentaje_tareas,
                                porcentaje_examenes
                            );
                            temas.Add(tema);
                            Console.WriteLine($"    -> Agregado: Tema '{nombreTema}' con tarea '{descripcionTarea}'");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"    -> Tema '{nombreTema}' omitido. No tiene tareas.");
                    }
                }

                Console.WriteLine($"=== RESULTADO FINAL: {temas.Count} registros para enviar a la API ===");

                // Solo llamar a la API si hay temas con tareas
                if (temas.Any())
                {
                    PlanificacionAPI.CrearPlanificacion(temas);
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Create: {ex.Message}");
                ModelState.AddModelError("", "Ocurrió un error al procesar la solicitud.");
                return View();
            }
        }

        // GET: PlanificacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanificacionController/Edit/5
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

        // GET: PlanificacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanificacionController/Delete/5
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
