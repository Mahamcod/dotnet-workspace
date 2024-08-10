using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Uploadincore.Data;
using Uploadincore.Models;

namespace Uploadincore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                //string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                //string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                FileUpload fileUpload = new FileUpload
                {
                    FilePath = "/uploads/" + fileName
                };

                _context.FileUploads.Add(fileUpload);
                await _context.SaveChangesAsync();

                ViewBag.Message = "File uploaded successfully.";
                ViewBag.FilePath = fileUpload.FilePath;
            }
            else
            {
                ViewBag.Message = "Please select a file to upload.";
            }

            return View();
        }

       

    }
}
