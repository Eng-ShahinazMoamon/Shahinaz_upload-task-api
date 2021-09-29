using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uploud_task_api.DAL.Models;
using uploud_task_api.DAL.ViewModel;

namespace uploud_task_api.DBL.Repository
{
    public interface IFileDetails
    {
        IEnumerable<FileVm> GetAllFileDetails();
        FileDetailEntity GetFileDetailsById(int id);
        void InsertFileDetails(FileVm fileVm);
        void DeleteFileDetails(int id);
        void UpdateFileDetails(int id ,FileDetailEntity fileDetails);
        void Save();

    }
}
