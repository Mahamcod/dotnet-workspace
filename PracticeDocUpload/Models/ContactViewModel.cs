
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeDocUpload.Models
{
    public class ContactViewModel
    {


        [Required]
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}