using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Upload.Models;

namespace Upload.Controllers
{
    public class ContactFormController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: ContactForm/Submit
        public ActionResult Submit()
        {
            return View();
        }

        // POST: ContactForm/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(ContactForm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Handle file upload
                    if (Request.Files["document"] != null && Request.Files["document"].ContentLength > 0)
                    {
                        var file = Request.Files["document"];
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);

                        file.SaveAs(filePath);

                        model.DocumentPath = fileName; // Save the file name or path to the database
                    }

                    // Save the model to the database
                    _context.ContactForms.Add(model);
                    _context.SaveChanges();

                    return RedirectToAction("Index"); // Redirect to a different action or view
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while processing the form: " + ex.Message);
                }
            }

            return View(model); // Return the view with the model if validation fails
        }
    }
}
