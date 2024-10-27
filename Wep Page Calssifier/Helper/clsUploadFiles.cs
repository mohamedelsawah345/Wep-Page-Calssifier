
using Microsoft.AspNetCore.Http;
namespace Wep_Page_Calssifier.Helper
{
    public class clsUploadFiles
    {

        public static string UpLoadFile(string FolderName, IFormFile File)
        {
            try
            {
                // تحديد مسار المجلد داخل wwwroot
                string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", FolderName);

                // التأكد من أن المجلد موجود، وإن لم يكن، سيتم إنشاؤه
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                // إنشاء اسم فريد للملف
                string FileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);

                // تحديد المسار النهائي للملف
                string FinalPath = Path.Combine(FolderPath, FileName);

                // نسخ الملف إلى المسار النهائي
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }

                // إرجاع اسم الملف ليتم تخزينه في قاعدة البيانات
                return FileName;
            }
            catch (Exception ex)
            {
                // إرجاع رسالة الخطأ في حالة حدوث مشكلة
                return ex.Message;
            }
        }
        //public static string UploadFile(IFormFile File)
        //{

        //    try
        //    {
        //        //catch the folder Path and the file name in server
        //        // 1 ) Get Directory
        //        string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + "Files";


        //        //2) Get File Name
        //        string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);
        //        //Guid => Word contain from 36 character

        //        // 3) Merge Path with File Name
        //        string FinalPath = Path.Combine(FolderPath, FileName);
        //        //combine put /

        //        //4) Save File As Streams "Data Overtime"
        //        using (var Stream = new FileStream(FinalPath, FileMode.Create))
        //        {
        //            File.CopyTo(Stream);
        //        }

        //        return FileName;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }

        //}


        public static string RemoveFile(string fileName)
        {

            try
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", "TextFile", fileName);

                if (File.Exists(directory))
                {
                    File.Delete(directory);
                    return "File Deleted";
                }

                return "File Not Deleted";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
