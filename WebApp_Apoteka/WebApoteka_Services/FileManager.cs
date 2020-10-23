using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Apoteka.WebApoteka_Interfaces;

namespace WebApp_Apoteka.Entity_Framework
{
    public class FileManager : IFileManager
    {
        private string _imagePath;

        public string GetImagePath() { return _imagePath; }
        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"];
        }
        public FileStream imageStream(string imageName)
        {
            return new FileStream(Path.Combine(_imagePath, imageName), FileMode.Open, FileAccess.Read);
        }
        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var SavePath = Path.Combine(_imagePath);
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));


                var fileName = $"img_{Guid.NewGuid().ToString()}{mime}";

               
                using (var fileStream = new FileStream(Path.Combine(SavePath, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return fileName;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error";
            }
        }
        public void DeleteImage(string imageName)
        {
            File.Delete(Path.Combine(_imagePath, imageName));
        }
    }
}
