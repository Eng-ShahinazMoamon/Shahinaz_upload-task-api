using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using uploud_task_api.DAL.Models;
using uploud_task_api.DAL.ViewModel;

namespace uploud_task_api.DBL.Repository
{
    public class FileDetailsRepo : IFileDetails
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        public FileDetailsRepo(ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env )
        {
            _context = context;
            _env = env;
        }

        public IEnumerable<FileVm> GetAllFileDetails()
        {

            var getList = _context.FileDetailEntity.OrderByDescending(a => a.CreationDate).ToList();
            var listVm = new List<FileVm>();
            foreach (var item in getList)
            {
                var fileVm = new FileVm();
                fileVm.Id = item.Id;
                fileVm.DocumentDescription = item.DocumentDescription;
                fileVm.DocumentTitle = item.DocumentTitle;
                // fileVm.DocumentURL = item.DocumentURL;
                fileVm.CreationDate = item.CreationDate.ToShortDateString();
                listVm.Add(fileVm);
            }

            return listVm;
        }

        public FileDetailEntity GetFileDetailsById(int id)
        {
            var entity = _context.FileDetailEntity.Find(id);
            //entity.DocumentURL = Path.Combine(_env.WebRootPath, "UploadedFile", entity.DocumentURL);
            return entity;

        }


        public void DeleteFileDetails(int id)
        {
            var entity = _context.FileDetailEntity.Find(id);
            _context.FileDetailEntity.Remove(entity);
            Save();
        }

        public void InsertFileDetails(FileVm fileVm)
        {
            var dbPath = "";

            //Get file
            if (fileVm.File != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedFile");

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileVm.File.FileName;
                dbPath = uniqueFileName;
                using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
                {
                    fileVm.File.CopyTo(fileStream);
                }
            }
            string ext = Path.GetExtension(dbPath);
            var checkedTesult =checkedOnTitle(fileVm.DocumentTitle);
            if (ext == ".jpg" || ext == ".png" || ext == ".pdf" || checkedTesult)
            {
                var fileDetails = new FileDetailEntity();
                fileDetails.DocumentDescription = fileVm.DocumentDescription;
                fileDetails.DocumentTitle = fileVm.DocumentTitle;
                fileDetails.DocumentURL = dbPath;
                fileDetails.CreationDate = DateTime.Now;
                _context.FileDetailEntity.Add(fileDetails);
                Save();
            }
            else
            {
                throw new InvalidOperationException("Unavaliable File Extention Or Existing File Name ");
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateFileDetails(int id, FileDetailEntity fileDetails)
        {
            var entity = _context.FileDetailEntity.Find(id);

        }


        public bool checkedOnTitle(string title)
        {
            var check = _context.FileDetailEntity.Where(a => a.DocumentTitle == title).FirstOrDefault();
            if (check == null){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
