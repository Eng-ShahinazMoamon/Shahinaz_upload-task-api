using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uploud_task_api.DAL.Models;
using uploud_task_api.DAL.ViewModel;
using uploud_task_api.DBL.Repository;

namespace uploud_task_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly IFileDetails _repo;

        public FileController(IFileDetails repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllFile()
        {
            return Ok(_repo.GetAllFileDetails());
        }
        [HttpGet("{id}")]
        public IActionResult GetFileById(int id )
        {
            return Ok(_repo.GetFileDetailsById(id));
        }

        [HttpPut("{id}")]
        public void UpdateFile([FromRoute]int id, [FromBody]FileDetailEntity file)
        {
            _repo.UpdateFileDetails(id,file);
        }

        [HttpDelete("{id}")]
        public void DeleteFile(int id)
        {
            _repo.DeleteFileDetails(id);
        }

        [HttpPost]
        public void PostNewFile([FromForm] FileVm fileVm)
        {
            _repo.InsertFileDetails(fileVm);
        }
    }
}
