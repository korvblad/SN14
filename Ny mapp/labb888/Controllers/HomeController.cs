
using labb888.Models;
using labb888.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;


namespace labb888.Controllers
{

    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        // Konstruktor
        public HomeController()
            : this(new XmlRepository())
        {
        }

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(_repository.GetContact());
        }

        #region Skapa kontakt
        // Skapa kund
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Email, Date")]Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddContact(contact);
                    _repository.Save();

                    TempData["success"] = string.Format("{0} {1} sparades", contact.FirstName, contact.LastName);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Create");
            }
            return View(contact);
        }

        #endregion

        #region Redigera kontakt
        //Redigera kontakt
        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_POST(Guid id)
        {
            var contactUpdate = _repository.GetContact(id);

            if (contactUpdate == null)
            {
                return HttpNotFound();
            }
            if (TryUpdateModel(contactUpdate, string.Empty, new string[] { "FirstName", "LastName", "Email" }))
            {
                try
                {
                    _repository.EditContact(contactUpdate);
                    _repository.Save();
                    TempData["success"] = string.Format("{0} {1} ändrades", contactUpdate.FirstName, contactUpdate.LastName);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            return View(contactUpdate);
        }
        #endregion

        #region Ta bort kontakt
        //Ta bort kontakt

        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var contactDelete = new Contact { Id = id };
                _repository.DeleteContact(contactDelete);
                _repository.Save();
            }
            catch (Exception)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}


