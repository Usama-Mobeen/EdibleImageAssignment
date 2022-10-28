using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdibleImageAssignment.Models
{
    public class Image
    {
      
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

        
    }
}
