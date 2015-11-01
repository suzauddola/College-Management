using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CollegeManagement.Manager;
using CollegeManagement.Model;

namespace CollegeManagement.RestService.Controllers
{
    public class StudentController : ApiController
    {
        StudentManager manager;
        public StudentController()
        {
            manager = new StudentManager();
        }

        public List<Student> Get()
        {
            List<Student> students = manager.GetStudents();
            return students;
        }

        public bool Post(Student student)
        {
            manager.Add(student);
            return true;
        }

        public bool Delete(int id)
        {
            manager.Delete(id);
            return true;
        }
    }
}
