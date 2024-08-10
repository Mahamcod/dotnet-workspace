using PracticeDocUpload.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PracticeDocUpload.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactDbcontext _context;

        public ContactController()
        {
            _context = new ContactDbcontext();
        }

        // GET: Contact
        public ActionResult SubmitContact()
        {
            return View();
        }

        // POST: Contact/SubmitContact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitContact(Contact model, HttpPostedFileBase UploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (UploadedFile != null && UploadedFile.ContentLength > 0)
                {
                    // Generate file name and path
                    var fileName = Path.GetFileName(UploadedFile.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);

                    // Ensure the directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Save file to the server
                    UploadedFile.SaveAs(filePath);

                    // Save the relative path or just the file name as needed
                    model.FilePath = fileName;

                    // Save to the database
                    _context.Contacts.Add(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("SubmitContact");
                }
                else
                {
                    ModelState.AddModelError("UploadedFile", "Please upload a valid file.");
                }
            }

            return View(model); // Return to the view with validation errors if any
        }
    }
}
