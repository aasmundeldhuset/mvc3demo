using System.Configuration;
using System.IO;
using System.Web;

namespace BusinessLogic
{
    public class AttachmentLogic
    {
        public void SaveAttachment(int id, HttpPostedFileBase uploadedFile)
        {
            string targetPath = GetTargetPath(id);
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
            uploadedFile.SaveAs(targetPath);
        }

        public Stream LoadAttachment(int id)
        {
            return File.OpenRead(GetTargetPath(id));
        }

        private static string GetTargetPath(int id)
        {
            return Path.Combine(ConfigurationManager.AppSettings["AttachmentDirectory"], id + ".pdf");
        }
    }
}
