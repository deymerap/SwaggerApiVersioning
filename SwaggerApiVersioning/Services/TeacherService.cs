using SwaggerApiVersioning.IServices;
using SwaggerApiVersioning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerApiVersioning.Services
{
    public class TeacherService : ITeacherService
    {
        List<Teacher> _teachers = new List<Teacher>();
        public TeacherService()
        {
            for (int i = 0; i < 9; i++)
            {
                _teachers.Add(
                    new Teacher()
                    {
                        TeachertId = i,
                        Name = $"Teacher {i}",
                        Subject = $"Subject{i}"
                    });
            }
        }
        public List<Teacher> Delete(int teacherId)
        {
            _teachers.RemoveAll(x => x.TeachertId == teacherId);
            return _teachers;
        }

        public List<Teacher> Gets()
        {
            return _teachers;
        }

        public List<Teacher> Save(Teacher teacher)
        {
            _teachers.Add(teacher);
            return _teachers;
        }
    }
}
