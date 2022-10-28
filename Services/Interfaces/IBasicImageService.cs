using EdibleImageAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdibleImageAssignment.Services.Interfaces
{
    public interface IBasicImageService
    {
        bool SaveImage(Image image);
        bool DeleteImage(string name);

        List<string> GetAllFiles();

        byte[] GetImage(string image);
    }
}
