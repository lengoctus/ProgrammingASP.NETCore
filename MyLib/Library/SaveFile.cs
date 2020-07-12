using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Library
{
    public static class SaveFile
    {
        public async static Task<string> SaveImage(IFormFile file, string PathFile, IWebHostEnvironment _webHosting)
        {
            try
            {
                // Get time today
                DateTime today = DateTime.Now;

                // Create filename
                string filename = today.Year.ToString() + today.Month.ToString() + today.Day + "_" + today.Hour.ToString() + today.Minute.ToString() + today.Second.ToString() + file.FileName;

                // Create File: wwwroot\pathFile\file
                string newFile = $"{_webHosting.WebRootPath}\\{PathFile}\\{filename}";
                using (FileStream fs = System.IO.File.Create(newFile))
                {
                    file.CopyTo(fs);
                    await fs.FlushAsync();
                };
                return await Task.FromResult(filename);
            }
            catch (Exception e)
            {
                return await Task.FromResult<string>(null);
            }
        }

        public static bool Remove(string filename, string PathFile, IWebHostEnvironment _WebHosting)
        {
            try
            {
                string file = $"{_WebHosting.WebRootPath}\\{PathFile}\\{filename}";
                if (File.Exists(file))
                {
                    File.Delete(file);
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
