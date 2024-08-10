using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentEmailSend.Controllers
{
    using FluentEmail.Core;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class EmailController : Controller
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailController(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public IActionResult Index()
        {
            // Return the view for sending a test email
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync()
        {
            var response = await _fluentEmail
                .To("mahiihassan68@gmail.com")
                .Subject("Test Email")
                .Body("This is a test email sent using FluentEmail.")
                .SendAsync();

            if (response.Successful)
            {
                ViewBag.Message = "Email sent successfully!";
            }
            else
            {
                ViewBag.Message = "Failed to send email.";
            }

            // Return the view with a success or error message
            return View("Index");
        }
    }

}
