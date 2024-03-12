using aspMVC.Data;
using aspMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace aspMVC.Services
{
    public interface IStudentService : IServiceGeneral<Student>
    {
        void SetDbContext(AppDbContext DbContext);
        // public void MemoryAddSubject(int studentId, int subjectId, ISubjectService subjectService);
        public void AddSubject(int studentId, int subjectId, ISubjectService subjectService);
        Task<Student> FindByName(string name);
    }

    public class StudentService : IStudentService
    {
        public AppDbContext DbContext { get; set; }

        public Dictionary<int, Student> StudentsList;
        private int _lastId;

        private static StudentService? _instance;

        public static StudentService? GetInstance()
        {
            return _instance = _instance ?? new StudentService();
        }

        private StudentService()
        {
            StudentsList = new Dictionary<int, Student>
            {
                { 0, new Student() { Id = 0, Email = "email0", Name = "name0" } },
                { 1, new Student() { Id = 1, Email = "email1", Name = "name1" } },
                { 2, new Student() { Id = 2, Email = "email2", Name = "name2" } },
                { 3, new Student() { Id = 3, Email = "email3", Name = "name3" } }
            };
            _lastId = 3;
        }

        //Memory storage //////////////////////////////////
        // public Student AddToMemory(Student student)
        // {
        //     _lastId++;
        //     this.StudentsList.Add(_lastId, student);
        //     return student;
        // }
        //
        // public Dictionary<int, Student> MemoryFindAll()
        // {
        //     return this.StudentsList;
        // }
        //
        // public Student MemoryDelete(int studentId)
        // {
        //     Student result = StudentsList[studentId];
        //     StudentsList.Remove(studentId);
        //     return result;
        // }
        //
        // public Student MemoryFindById(int studentId)
        // {
        //     return this.StudentsList[studentId];
        // }
        //
        // public void MemoryAddSubject(int studentId, int subjectId, ISubjectService subjectService)
        // {
        //     StudentsList[studentId].Subjects.Add(subjectService.MemoryFindById(subjectId));
        // }

        //DB storage //////////////////////////////
        public void SetDbContext(AppDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public void AddSubject(int studentId, int subjectId, ISubjectService subjectService)
        {
            // Subject _subject = subjectService.FindById()
        }

        public async Task Add(Student student)
        {
            DbContext.Add(student);
            await DbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> FindAll()
        {
            List<Student> listStudents = new List<Student>();
            return await DbContext.Students.ToListAsync();
        }

        public async Task<Student> FindById(int id)
        {

            return await DbContext.Students.FindAsync(id);
        }

        public Task<Student> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}