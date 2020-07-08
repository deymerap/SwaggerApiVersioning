using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwaggerApiVersioning.IServices;
using SwaggerApiVersioning.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwaggerApiVersioning.Controllers
{
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherService _teacherService;
        public TeacherController(ITeacherService TeacherService)
        {
            _teacherService = TeacherService;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public List<Teacher> Gets()
        {
            return _teacherService.Gets();
        }

        //// GET api/<TeacherController>/5
        //[HttpGet("{id}", Name = "Get")]
        //public Teacher Get(int id)
        //{
        //    return _teacherService.Get(id);
        //}

        // POST api/<TeacherController>
        [HttpPost]
        public List<Teacher> Post([FromBody] Teacher Teacher)
        {
            return _teacherService.Save(Teacher);
        }

        //// PUT api/<TeacherController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public List<Teacher> Delete(int Id)
        {
            return _teacherService.Delete(Id);
        }
    }
}
