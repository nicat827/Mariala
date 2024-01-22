using Mariala.Utilities.Enums;

namespace Mariala.Utilities.Extencions
{
    public static class FileHelper
    {
        public static bool CheckFileType(this IFormFile file, FileType type)
        {
            switch (type)
            {
                case (FileType.Image):
                    if (file.ContentType.Contains("image/")) return true;
                    return false;
                case (FileType.Audio):
                    if (file.ContentType.Contains("audio/")) return true;
                    return false;
                case (FileType.Video):
                    if (file.ContentType.Contains("video/")) return true;
                    return false;
                default : return false;
            }

        }

        public static bool CheckFileSize(this IFormFile file, int maxSize)
        {
            if (file.Length <= maxSize * 1024) return true;
            return false;
        }

        public static async Task<string> CreateFileAsync(this IFormFile file, string rootPath, params string[] folders)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName.Substring(file.FileName.LastIndexOf("."));
            string path = fileName._getPath(rootPath, folders);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }

        public static void DeleteFile(this string fileName, string rootPath, params string[] folders)
        {
            string path = fileName._getPath(rootPath, folders);
            if (File.Exists(path)) File.Delete(path);
        }

        private static string _getPath(this string fileName, string rootPath, params string[] folders)
        {
            string path = rootPath;
            foreach(string folder in folders)
            {
                path = Path.Combine(path, folder);
            }
            path = Path.Combine(path, fileName);
            return path;
        }
    }
}
