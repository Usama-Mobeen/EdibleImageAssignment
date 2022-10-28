using EdibleImageAssignment.Models;
using EdibleImageAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EdibleImageAssignment.Services
{
    public class BasicImageService : IBasicImageService
    {
        
        private readonly IHostingEnvironment _hostingEnvironment;

        public BasicImageService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
           
        }

        public bool DeleteImage(string name)
        {
            var getFileNamefile = _hostingEnvironment.ContentRootPath + "\\Images\\" + name;
            if ((System.IO.File.Exists(getFileNamefile)))
            {
                System.IO.File.Delete(getFileNamefile);
                return true;
            }
            else
            {

                return false;
            }
        }

        public List<string> GetAllFiles()
        {
            string[] filePaths = Directory.GetFiles(Path.Combine(_hostingEnvironment.ContentRootPath, "Images/"));

            List<string> files = new List<string>();
            if (filePaths.Length > 0)
            {
                foreach (string filePath in filePaths)
                {
                    files.Add(Path.GetFileName(filePath));
                }
                return files;
            }
            else
            {
                return files;
            }
        }

        public byte[] GetImage(string ImageName)
        {
            byte[] arr = {};  
            var getFileNamefile = _hostingEnvironment.ContentRootPath + "\\Images\\" + ImageName;
            if (System.IO.File.Exists(getFileNamefile))
            {
                byte[] Picture = System.IO.File.ReadAllBytes(getFileNamefile);

                return Picture;
            }
            else
            {
                return arr;
            }
        }

        public bool SaveImage(Image image)
        {
            if (image.ImageFile.Length > 0)
            {
               
                    string projectRootPath = _hostingEnvironment.ContentRootPath;
                    if (!Directory.Exists(_hostingEnvironment.ContentRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_hostingEnvironment.ContentRootPath + "\\Images\\");
                    }
                    using (System.IO.FileStream fileStream = System.IO.File.Create(_hostingEnvironment.ContentRootPath + "\\Images\\" + image.Name))
                    {
                        using var ms = new MemoryStream();
                         image.ImageFile.CopyTo(ms);
                        image.ImageFile.CopyTo(fileStream);
                        fileStream.Flush();
       
                    }
            
            }
            return true;
        }
    }
}
