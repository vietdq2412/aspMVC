using aspMVC.Data;
using aspMVC.Models;
using aspMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext context;
        public readonly IStudentService StudentService;
        public readonly ISubjectService SubjectService;
        public StudentController(AppDbContext dbContext, IStudentService studentService, ISubjectService subjectService)
        {
            
            this.context = dbContext;
            this.StudentService = studentService;  
            this.SubjectService = subjectService;  
            StudentService.SetDbContext(context);
            SubjectService.SetDbContext(context);

        }
        public IActionResult Index()
        {
           
            List<Student> students = StudentService.FindAll().Result;
            // List<Student> students = _studentService.MemoryFindAll().Values.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentService.Add(student);
            // _studentService.AddToMemory(student);
            return RedirectToRoute("student", new { controller = "Student", action = "Index" });
        }

        public IActionResult Details(int id)
        {
            // List<Subject> subjects = _subjectService.MemoryFindAll().Values.ToList();
            // Student student = _studentService.MemoryFindById(id);

            Student student = StudentService.FindById(id).Result;
            List<Subject> subjects = SubjectService.FindAll().Result;

            ViewData["subject"] = subjects;
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            Student student = StudentService.FindById(id).Result;
            // Student student = _studentService.MemoryDelete(id);
            return RedirectToRoute("student", new { controller = "Student", action = "Index", });
        }

        public IActionResult Edit(int id)
        {
            return null;
        }

        public IActionResult AddSubject(int studentId, int subjectId)
        {
            // _studentService.MemoryAddSubject(studentId, subjectId, this._subjectService);
            return RedirectToRoute("student", new { controller = "Student", action = "Details", Id = studentId });
        }
    }
}
