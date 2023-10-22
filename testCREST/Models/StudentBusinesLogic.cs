using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace testCREST.Models
{
    public  class StudentBusinesLogic
    {
        public DataContext _context;
        //internal object stu;

        public   StudentBusinesLogic(DataContext context)
        {
            _context = context;

        }
        public List<Student> AllStudent()
        {
            return _context.students.Include("Facluty").ToList();
        }
        public List<Facluty> Facluties()
        {
            return _context.faclutys.ToList();
        }
        public bool Add( Student student)
        {
            if (_context.students.FirstOrDefault(s => s.ID == student.ID) == null)
            {
                _context.students.Add(student);
                _context.SaveChanges();
                return true;
            }
            else { return false; }

           
        }
        public Student getById(int id)
        {
            return _context.students.Include("Facluty").FirstOrDefault(s => s.ID == id);
        }
        public bool Delete(int id)
        {
            
            _context.students.Remove(getById(id));
            _context.SaveChanges();
            return true;
        }
        public bool Update ( Student student)
        {
            var std = _context.students.FirstOrDefault(s => s.ID == student.ID);
            if(std != null) 
            {

                std.ID = student.ID;
                std.Name = student.Name;
                std.Graduated = student.Graduated;
                std.Gpa = student.Gpa;
                std.FaclutyId = student.FaclutyId;
                //_context.Entry(std).State=EntityState.Modified;//selete std and put my modifiy 
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
