using Biblioteket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteket.Models;
using System.Net;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Biblioteket.Controllers
{
    public class HomeController : Controller
    {
        // Lista kunder 
        [HttpGet]
        public ActionResult Index()
        {
            List<CustomerList> customers;
                        
            using (var ctx = new MassaData())
            {
                var GetCustomerLoans = from c in ctx.Customers
                                 join l in ctx.Loans on c.CustomerID equals l.CustomerID
                                 where l.ReturnDate.HasValue
                                 group c by c.CustomerID into grp
                                 select new { key = grp.Key, Count = grp.Count() };


                    customers = (from c in ctx.Customers
                                join lc in GetCustomerLoans on c.CustomerID equals lc.key into lcs
                                from lc in lcs.DefaultIfEmpty()
                                where c.ActiveCustomer == true
                                select new CustomerList{
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    TelephoneNumber = c.TelephoneNumber,
                    Email = c.Email,
                    Gender = c.Gender,
                    BirthYear = c.BirthYear,
                    Loans = lc == null ? 0 : lc.Count
                    
                }).ToList();    
   
            }
            return View(customers);
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int? id)
            {
                CustomerList customer;
                using(var ctx = new MassaData())
                {
                    var activeLoans = ctx.Loans.Any(x => x.CustomerID == id.Value);
           
                    var delete = from c in ctx.Customers
                                 where c.CustomerID == id
                               select new CustomerList
                               {

                                   CustomerID = c.CustomerID,
                                   FirstName = c.FirstName,
                                   LastName = c.LastName,
                                   Email = c.Email,
                                   BirthYear = c.BirthYear,
                                   TelephoneNumber = c.TelephoneNumber,
                                   Gender = c.Gender,
                                   ActiveLoans = activeLoans
                               };
                    customer = delete.FirstOrDefault();
                }
                return View(customer);
            }


        [HttpPost]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                using (var ctx = new MassaData())
                {
                    var delete =
                        from c in ctx.Customers
                        where c.CustomerID == id
                        select c;

                 
                    foreach (var c in delete)
                      
                    {
                        c.ActiveCustomer = false;
                    }

                    try
                    {       
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
            }
            catch (Exception)
            {

                return RedirectToAction("DeleteCustomer", new { id = id });
            }
            return RedirectToAction("Index");
        }

        // GET: CustomerDetails
        [HttpGet]
        public ActionResult CustomerDetails(int? id)
        {
                  CustomerDetails customer;
                using (var ctx = new MassaData())
                {

                    var loans = ctx.Loans.Any(x => x.CustomerID == id.Value && !x.LoanReturn);

                    var query = 
                            (from l in ctx.Loans
                             join c in ctx.Copies on l.CopyID equals c.CopyID
                             join b in ctx.Books on c.BookID equals b.BookID
                             join cc in ctx.Customers on l.CustomerID equals cc.CustomerID
                             where l.CustomerID == id
                             select new CustomerDetails
                             {
                                    CustomerID = cc.CustomerID,
                                    FirstName = cc.FirstName,
                                    LastName = cc.LastName,
                                    TelephoneNumber = cc.TelephoneNumber,
                                    Email = cc.Email,
                                    Gender = cc.Gender,
                                    BirthYear = cc.BirthYear,
                                    Name = c.Book.Name,
                                    BookID = c.BookID,
                                    LoanDate = l.LoanDate,
                                    ReturnDate = l.ReturnDate,
                                    

                                    LateReturn = DbFunctions.AddDays(l.LoanDate, 15) < DateTime.Now
                             }).ToList();
                    customer = query.FirstOrDefault();
                }
                
            return View(customer);
        }
    }
}