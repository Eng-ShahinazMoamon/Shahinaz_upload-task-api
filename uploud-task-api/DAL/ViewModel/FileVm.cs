using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uploud_task_api.DAL.ViewModel
{
    public class FileVm
    {
        public int Id { get; set; }

        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentURL { get; set; }
        public string CreationDate { get; set; }
        public IFormFile File { get; set; }

    }
}
