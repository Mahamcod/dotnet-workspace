using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice.Controllers
{
    public class ContactController : Controller
    {
        

       

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            return View();
        }

        
    }
}
