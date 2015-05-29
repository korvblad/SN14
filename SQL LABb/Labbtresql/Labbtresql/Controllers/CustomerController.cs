using Labbtresql.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Labbtresql.Controllers
{

    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<CustomerViewModel> customers;

            using (var ctx = new BibliotekEntities())
            {
                

            }
            return View(customers);
        }
    }
}