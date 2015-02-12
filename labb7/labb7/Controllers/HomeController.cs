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
            return View();
        }

        [HttpPost]
        public ActionResult Index(Nullable<int> number)
        {

            if(number.HasValue)
            {
                var list = GetList();
                list.Add(number.Value);
                //Är allt ok gå vidare
                return View(list);
              
            }

            ModelState.AddModelError("number", "Ange ett tal");


            return View();
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