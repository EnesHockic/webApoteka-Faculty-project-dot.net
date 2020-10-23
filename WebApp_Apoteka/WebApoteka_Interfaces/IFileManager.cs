using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.WebApoteka_Interfaces
{
    public interface IFileManager
    {
        public string GetImagePath();
        FileStream imageStream(string imageName);
        Task<string> SaveImage(IFormFile image);

        public void DeleteImage(string imageName);
    }
}
