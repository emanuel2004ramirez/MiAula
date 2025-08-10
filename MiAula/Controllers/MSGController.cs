using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAula.Controllers
{
    public class MSGController : Controller
    {
        // GET: MSGController
        public ActionResult SUCCESS()
        {
            return View();
        }

        // GET: MSGController/Details/5
        public ActionResult FAILED()
        {
            return View();
        }

        public ActionResult FAILED_DELETE()
        {
            return View();
        }

        public ActionResult SUCCESS_DELETE()
        {
            return View();
        }

        public ActionResult FAILED_SEARCH()
        {
            return View();
        }

        public ActionResult FAILED_EDIT()
        {
            return View();
        }

        public ActionResult SUCCESS_EDIT()
        {
            return View();
        }
    }
}
