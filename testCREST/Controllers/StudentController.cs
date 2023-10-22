using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using testCREST.Models;

namespace testCREST.Controllers
{
    public class StudentController : Controller
    {
        //DataContext _Dcontext;
        //public StudentController(DataContext Dcontext)
        //{
        //    _Dcontext = Dcontext;
        //}
          StudentBusinesLogic Tstd;
        public StudentController(StudentBusinesLogic businesLogic)
        {
            Tstd = businesLogic;
        }
       
        public IActionResult Index()

        {  
            return View(Tstd.AllStudent());
         }
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.FaclutyId = new SelectList(Tstd.Facluties(), "Id", "Name");
            return View(new Student() );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("img","Name", "FaclutyId", "Graduated","Gpa")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Tstd.Add(student);
                    return RedirectToAction("Index");
                }
                catch(Exeption e)
                {
                    ViewBag.FaclutyId = new SelectList(Tstd.Facluties(), "Id", "Name");
                    ModelState.AddModelError("Database", "error in add database");
                    return View(student);
                }
            }
            ViewBag.FaclutyId = new SelectList(Tstd.Facluties(), "Id", "Name");
            return View(student);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Student std = Tstd.getById(id);
            ViewData["FaclutyId"] = new SelectList(Tstd.Facluties(), "Id", "Name", std.FaclutyId);
            
            return View(std);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Tstd.Update(student);
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    ViewBag.FaclutyId = new SelectList(Tstd.Facluties(), "Id", "Name",student.FaclutyId);
                    ModelState.AddModelError("database", "database is error");

                }
                ViewBag.FaclutyId = new SelectList(Tstd.Facluties(), "Id", "Name", student.FaclutyId);
                return View(student);
          
            }
            ViewBag.FaclutyId = new SelectList(Tstd.Facluties(), "Id", "Name", student.FaclutyId);
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            Tstd.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detils(int id)
        { 
            var std= Tstd.getById(id);
            return View(std);
        }
        //public IActionResult Detils(int id)
        //{

        //}







    }

    
}
