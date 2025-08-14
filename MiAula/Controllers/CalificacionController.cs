using MiAula.Models;
using MiAula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

namespace MiAula.Controllers
{
    public class CalificacionController : Controller
    {
        // GET: CalificacionController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }


        public ActionResult IndexSeccion(string grado)
        {
            return View((object)grado);
        }

  
        public ActionResult Ver_calificacion_seccion(string grado)
                {
            return View((object)grado);
        }

        

        public ActionResult ver_seleccionarMateria(string grado, string seccion)
        {
            return View(ClaseAPI.ClaseConPlanificacion(grado, seccion));
        }


        public ActionResult SeleccionarMateria2(string grado, string seccion)
        {
            return View(ClaseAPI.ClaseConPlanificacion(grado, seccion));
        }

        public ActionResult ver_calificacion_Seleccionar_Alumno(int id_clase)
        {

            Calificar_Lista_Alumno_id_Clase e = new Calificar_Lista_Alumno_id_Clase();

            e.alumnos = AlumnoAPI.Lista_alumno_calificados(id_clase);
            e.id_clase = id_clase;

            return View(e);
        }

        public ActionResult Ver_Tareas_calificadas(int id_clase, int id_alumno)
        {
            List<Ver_Tareas_calificadas> e = CalificarAPI.Lista_Calificacion_Tareas(id_clase, id_alumno);
            List<Tarea> tareas = new List<Tarea>();

            for (int i = 0; i < e.Count; i++)
            {
               e[i].alumno=  AlumnoAPI.get_Alumno(id_alumno);
                Console.WriteLine(e[i].alumno.Nombre);
               e[i].tarea = TareaAPI.Tarea_ByID(e[i].id_tarea);
                Console.WriteLine(e[i].tarea.Tareaa);
                e[i].clase = ClaseAPI.get_Clase(id_clase);
                Console.WriteLine(e[i].clase.Nombre);
                e[i].planificacion = PlanificacionAPI.VerPlanificacion(id_clase);
            }

            

            return View(e);

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

        [HttpPost]
        public ActionResult Calificar_Tareas(IFormCollection f,int id_clase,int id_alumno, int id_tarea)
        {
            int total_tareas_calificada = 0;
            calificacion_examen examen = new calificacion_examen(id_alumno,id_clase, f["calificacion_examen.nota"], f["calificacion_examen.comentario"]);
            List<calificacion_tarea> tareas = new List<calificacion_tarea>();
            int suma = 0;
            int total_tareas = 0;
            while (!string.IsNullOrEmpty(f[$"calificaciones_tareas[{total_tareas_calificada}].nota"]))
            {
                total_tareas++;
                suma += int.Parse(f[$"calificaciones_tareas[{total_tareas_calificada}].nota"]);

                tareas.Add(new calificacion_tarea(int.Parse(f[$"calificaciones_tareas[{total_tareas_calificada}].id_tarea"]), id_alumno, id_clase, int.Parse( f[$"calificaciones_tareas[{total_tareas_calificada}].nota"]), f[$"calificaciones_tareas[{total_tareas_calificada}].comentario"]));
                total_tareas_calificada++;
            }

            TareaAPI.Calificar_Examen(examen);
            TareaAPI.Calificar_Tarea(tareas);
            CalificarAPI.Notas_Finales_Clases(new Notas_Finales_Clases(id_clase,id_alumno,suma));
            
            return RedirectToAction("index","Home");
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
