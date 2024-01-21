using Microsoft.AspNetCore.Http;

namespace Lumia.Helpers
{
    public static class FileManager
    {
        public static string Upload(this IFormFile file, string envPath, string folderPath)
        {
            string fileName = file.FileName;
            if (!Directory.Exists(envPath + folderPath))
            {
                Directory.CreateDirectory(envPath + folderPath);
            }
            string filePath = envPath + folderPath + fileName;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return fileName;
        }



        public static void Delete(this string ImgUrl, string envPath, string folderpath)
        {
            string filePath = envPath + folderpath+ImgUrl;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
