using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labb7.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = GetList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind( Include ="number")]Nullable<int> number)
        {
           // DateTime dt = (DateTime)Session["test"];

            if (Session.IsNewSession)
            {
                //Detta är en ny, dvs efter timeout
                return View("SessionError"); // skapa ny vy kallad ex SessionError, där du skriver ut felet
            }
            var list = GetList();
            

            if(!number.HasValue)
            {
                ModelState.AddModelError("number", "Ange ett tal");        
            }
            else
            {
                list.Add(number.Value);
            }

            

            //var list = GetList();
            return View(list);
        }

       private List<int> GetList()
        {
            var list = Session["list"] as List<int>;
            if (list == null)
            {
                list = new List<int>();
                Session["list"] = list;
            }
            return list;
        }
    }
}