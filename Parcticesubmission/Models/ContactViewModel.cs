using System.Web;

namespace Parcticesubmission.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Define UploadedFile only once
        public HttpPostedFileBase UploadedFile { get; set; }

    }
}

