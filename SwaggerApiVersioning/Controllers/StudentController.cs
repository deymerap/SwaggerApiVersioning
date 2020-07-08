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
    [ApiVersion("1")]
    //[ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> Gets()
        {
            return _studentService.Gets();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}", Name ="Get")]
        public Student Get(int id)
        {
            return _studentService.Get(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public List<Student> Post([FromBody] Student student)
        {
            return _studentService.Save(student);
        }

        //// PUT api/<StudentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public List<Student> Delete(int Id)
        {
            return _studentService.Delete(Id);
        }
    }
}
