using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Parcticesubmission.Models;
using Practicesubmission.Models;

namespace Parcticesubmission.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Default constructor now initializes the context
        public ContactController()
        {
            _context = new ApplicationDbContext();
        }

        // Constructor with dependency injection
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contact/SubmitContact
        public ActionResult SubmitContact()
        {
            return View();
        }

        // POST: Contact/SubmitContact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
                {
                    // Generate file name and path
                    var fileName = Path.GetFileName(model.UploadedFile.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

                    // Ensure the directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Save file to the server
                    model.UploadedFile.SaveAs(filePath);

                    // Create a new Contact entity and save to the database
                    var contact = new Contact
                    {
                        Name = model.Name,
                        Email = model.Email,
                        FilePath= filePath // Save the file path
                    };

                    _context.ContactModels.Add(contact);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("SubmitContact"); // Redirect to a confirmation or list page
                }
            }

            return View(model); // Return to the view with validation errors if any
        }
    }
}
