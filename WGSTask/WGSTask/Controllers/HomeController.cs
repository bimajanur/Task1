using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WGSTask.Models;

namespace WGSTask.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        //inisialisasi entities
        ContactDataEntities _db;

        public HomeController()
        {
            //objek untuk entities di deklarasi pada main method
            _db = new ContactDataEntities();
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "My Contacts!";

            ViewData.Model = _db.ContactSets.ToList();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        //controller untuk Add
        public ActionResult Add()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(FormCollection form)
        {
            var contactToAdd = new ContactSet();

            // Deserialize (Include white list!)
            TryUpdateModel(contactToAdd, new string[] { "Name", "NoHP" }, form.ToValueProvider());

            // Validate
            if (String.IsNullOrEmpty(contactToAdd.Name))
                ModelState.AddModelError("Name", "Name is required!");
            if (String.IsNullOrEmpty(contactToAdd.NoHP))
                ModelState.AddModelError("NoHP", "NoHP is required!");

            // If valid, save contact to database
            if (ModelState.IsValid)
            {
                _db.AddToContactSets(contactToAdd);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Otherwise, reshow form
            return View(contactToAdd);
        }

        //controller untuk Edit
        public ActionResult Edit(int id)
        {
            // Get contact to update
            var contactToUpdate = _db.ContactSets.First(m => m.Id == id);

            ViewData.Model = contactToUpdate;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(FormCollection form)
        {
            // Get contact to update
            var id = Int32.Parse(form["id"]);
            var contactToUpdate = _db.ContactSets.First(m => m.Id == id);

            // Deserialize (Include white list!)
            TryUpdateModel(contactToUpdate, new string[] { "Name", "NoHP" }, form.ToValueProvider());

            // Validate
            if (String.IsNullOrEmpty(contactToUpdate.Name))
                ModelState.AddModelError("name", "name is required!");
            if (String.IsNullOrEmpty(contactToUpdate.NoHP))
                ModelState.AddModelError("nohp", "no hp is required!");

            // If valid, save contact to database
            if (ModelState.IsValid)
            {
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Otherwise, reshow form
            return View(contactToUpdate);
        }

        public ActionResult Delete(int id)
        {
            // Get contact to delete
            var contactToDelete = _db.ContactSets.First(m => m.Id == id);

            // Delete 
            _db.DeleteObject(contactToDelete);
            _db.SaveChanges();

            // Show Index view
            return RedirectToAction("Index");
        }
    }
}
