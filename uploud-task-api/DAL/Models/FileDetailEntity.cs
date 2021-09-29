using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uploud_task_api.DAL.Models
{
    public class FileDetailEntity
    {

        public int Id { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentURL { get; set; }
        public DateTime CreationDate { get; set; }
       
    }
}
