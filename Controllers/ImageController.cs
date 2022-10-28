using EdibleImageAssignment.Models;
using EdibleImageAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdibleImageAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly IBasicImageService _basicImageService;
        public ImageController(IHostingEnvironment hostingEnvironment, ILogger<ImageController> logger, IBasicImageService basicImageService)
        {

            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _basicImageService = basicImageService;
        }

        [HttpGet]
        [Route("Get-All-Files")]

        public List<string> Files()
        {
            try
            {
                var result = _basicImageService.GetAllFiles();

                if (result.Count > 0)
                {
                    _logger.LogInformation("Retrieve Files Successfully");
                    return result;
                }
                else
                {
                    _logger.LogError($"No Content Found");
                    return result;
                }

            }
            catch (Exception)
            {
                _logger.LogError("Error While Retrieving Files");
                throw;
            }

        }


        [HttpGet]
        [Route("Get-Image")]

        public IActionResult Show(string ImageName)
        {
            try
            {
                var Picture = _basicImageService.GetImage(ImageName);

                if (Picture.Length > 0)
                {
                    _logger.LogInformation($"Image Found With name [{ImageName}] ");
                    return File(Picture, "Image/png");
                }
                else
                {
                    _logger.LogError($"No Image Found With name [{ImageName}] ");
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                throw;
            }

        }

        [HttpPost]
        [Route("Upload-Image")]
        public async Task<string> ImageUpload([FromForm] Image file)
        {
            try
            {
                var result = _basicImageService.SaveImage(file);
                if (result)
                {
                    _logger.LogInformation($"Image Saved with name [{file.Name}]");
                    return $"Image saved at \\Images\\ with name " + file.Name;
                }
                else
                {
                    _logger.LogError($"Error while saving image with name [{file.Name}]");
                    return "Saving Failed";
                }


            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
                throw;
            }

         
        }

        [HttpPost]
        [Route("Delete-Image")]
        public string DeleteFile(string name)
        {
            try
            {
                var result = _basicImageService.DeleteImage(name);

                if (result)
                {
                    _logger.LogInformation($"File with name [{name}] is deleted at {DateTime.Now}");
                    return "File Deleted Successfully";
                }
                else
                {
                    _logger.LogError($"Error while deleting file [{name}] at {DateTime.Now}");
                    return "Error While Deleting";
                }


            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                throw;
            }

        }
    }
}
