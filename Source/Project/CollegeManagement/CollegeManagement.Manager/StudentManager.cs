using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeManagement.Model;

namespace CollegeManagement.Manager
{
    public class StudentManager
    {
        CollegeManagementDbEntities _db;

        public StudentManager()
        {
            _db = new CollegeManagementDbEntities();
        }

        public bool Add(Student student)
        {
            DbSet<Student> students = _db.Students;
            students.Add(student);
            _db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            Student s = _db.Students.FirstOrDefault(student => student.ID == id);
            if (s != null)
            {
                _db.Students.Remove(s);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Student> GetStudents()
        {
            return _db.Students.ToList();
        } 
    }
}
