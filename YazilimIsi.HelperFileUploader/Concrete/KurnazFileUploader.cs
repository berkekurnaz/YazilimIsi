using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YazilimIsi.HelperFileUploader.Abstract;

namespace YazilimIsi.HelperFileUploader.Concrete
{
    public class KurnazFileUploader : IKurnazFileUploader
    {

        public KurnazFileUploader()
        {

        }

        /* Yeni Bir Dosya Yukleme */
        public static async Task<bool> UploadFile(IFormFile Image, string ImageName,string FolderName)
        {
            bool isCompleted = false;
            if (Image == null || Image.Length == 0)
            {
                isCompleted = false;
            }
            else
            {
                string newImage = ImageName + Image.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + FolderName, newImage);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                isCompleted = true;
            }
            return isCompleted;
        }

        /* Var Olan Bir Dosya Guncelleme */
        public static async Task<bool> UpdateFile(IFormFile Image, string ImageName,string FolderName, string CurrentFileName, string DefaultRootFolderName)
        {
            bool isCompleted = false;
            if (Image == null || Image.Length == 0)
            {
                isCompleted = false;
            }
            else
            {
                if (CurrentFileName != DefaultRootFolderName)
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\" + FolderName + "\\" + CurrentFileName))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\" + FolderName + "\\" + CurrentFileName);
                    }
                }
                string newImage = ImageName + Image.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + FolderName, newImage);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                isCompleted = true;
            }
            return isCompleted;
        }

        /* Var Olan Bir Dosya Silme */
        public static bool DeleteFile(string FolderName, string CurrentFileName, string DefaultRootFolderName)
        {
            if (CurrentFileName != DefaultRootFolderName)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\" + FolderName + "\\" + CurrentFileName))
                {
                    File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\" + FolderName + "\\" + CurrentFileName);
                }
            }
            return true;
        }

    }
}
