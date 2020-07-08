using SwaggerApiVersioning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerApiVersioning.IServices
{
    public interface ITeacherService
    {
        List<Teacher> Gets();
        List<Teacher> Save(Teacher teacher);
        List<Teacher> Delete(int teacherId);
    }
}
