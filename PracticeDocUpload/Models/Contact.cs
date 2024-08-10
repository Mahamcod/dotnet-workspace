﻿using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeDocUpload.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [Email]
        public string Email { get; set; }


        [Required]
        public int Phone { get; set; }

        [Required]
        public string FilePath { get; set; }
        
    }
}