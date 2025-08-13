using API_MI_AULA.Models;
using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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

        public ActionResult VerTarea(int id)
        {
            VerTareaC ver = new VerTareaC();
            ver.Clase = ClaseAPI.get_Clase(id);
            ver.Tareas = TareaAPI.GetTarea_ByID(id);
            ver.planificacion = PlanificacionAPI.Planificacion(id);


            return View(ver);
        }

        public ActionResult DeleteP(int id)
        {

            

            return View(ClaseAPI.get_Clase(id));
        }

        [HttpPost]
        public ActionResult DeleteP(int id,IFormCollection collection)
        {

            if (PlanificacionAPI.EliminarPlanificacion(id))
            {
                return RedirectToAction("SUCCESS_DELETE", "MSG");

            }

            return RedirectToAction("FAILED_DELETE", "MSG");


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
                Examen examen = null; // Variable para el examen singular.

                // Validar y obtener datos básicos
                var fechainicio = collection["FechaInicio"];
                var fechafin = collection["FechaFin"];

                // Procesar Examen (se espera uno)
                float totalPuntosExamenes = 0;
                if (!string.IsNullOrEmpty(collection["examenes[0].Nombre"]))
                {
                    string nombreExamen = collection["examenes[0].Nombre"];
                    string fechaExamen = collection["examenes[0].Fecha"];
                    if (!float.TryParse(collection["examenes[0].Valor"], out float valorExamen))
                    {
                        ModelState.AddModelError("", "El valor del examen no es un número válido.");
                        return View();
                    }
                    totalPuntosExamenes += valorExamen;
                    examen = new Examen(id,nombreExamen, fechaExamen, valorExamen);
                    
                }

                // El cálculo de porcentajes ahora es dinámico, no se obtiene del formulario.
                float totalPuntosTareas = 0;

                int totalTemas = 0;
                while (!string.IsNullOrEmpty(collection[$"temas[{totalTemas}].Nombre"]))
                {
                    totalTemas++;
                }

                Console.WriteLine($"=== PROCESANDO {totalTemas} TEMAS ===");

                // Bucle para contar puntos de las tareas antes de crear los objetos
                for (int temaIndex = 0; temaIndex < totalTemas; temaIndex++)
                {
                    int totalTareasDelTema = 0;
                    while (!string.IsNullOrEmpty(collection[$"temas[{temaIndex}].Tareas[{totalTareasDelTema}].Descripcion"]))
                    {
                        if (float.TryParse(collection[$"temas[{temaIndex}].Tareas[{totalTareasDelTema}].Valor"], out float valorTarea))
                        {
                            totalPuntosTareas += valorTarea;
                        }
                        totalTareasDelTema++;
                    }
                }

                // Calcular los porcentajes totales después de contar todos los puntos
                float totalPuntos = totalPuntosTareas + totalPuntosExamenes;
                int porcentaje_tareas = 0;
                int porcentaje_examenes = 0;

                if (totalPuntos > 0)
                {
                    porcentaje_tareas = (int)Math.Round((totalPuntosTareas / totalPuntos) * 100);
                    porcentaje_examenes = (int)Math.Round((totalPuntosExamenes / totalPuntos) * 100);
                }

                // Bucle para crear los objetos Tema y Tarea con los porcentajes calculados
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

                    if (totalTareasDelTema > 0)
                    {
                        for (int tareaIndex = 0; tareaIndex < totalTareasDelTema; tareaIndex++)
                        {
                            string descripcionTarea = collection[$"temas[{temaIndex}].Tareas[{tareaIndex}].Descripcion"];
                            string tipoTarea = collection[$"temas[{temaIndex}].Tareas[{tareaIndex}].Tipo"];
                            string fechaLimiteTarea = collection[$"temas[{temaIndex}].Tareas[{tareaIndex}].Fecha_Entrega"];
                            float valorTarea = float.Parse(collection[$"temas[{temaIndex}].Tareas[{tareaIndex}].Valor"]);

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
                                porcentaje_examenes,
                                (int)valorTarea
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

                // Enviar los datos a la API si hay temas o examen
                if (temas.Any() || examen != null)
                {
                    T_E planificacion = new T_E
                    {
                        Tema = temas,
                        Examenes = examen
                    };
                    PlanificacionAPI.CrearPlanificacion(planificacion);
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
