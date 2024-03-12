using aspMVC.Data;
using aspMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace aspMVC.Services
{
    public interface ISubjectService: IServiceGeneral<Subject>
    {
        void SetDbContext(AppDbContext DbContext);

    }
    public class SubjectsService : ISubjectService
    {
        public AppDbContext DbContext { get; set; }

        public Dictionary<int, Subject> Subjects { get; }
        public int LastId { get; set; }

        private static SubjectsService? _instance;

        public static SubjectsService? GetInstance(AppDbContext? DbContext)
        {
            return _instance = _instance ?? new SubjectsService(DbContext);
        }

        private SubjectsService(AppDbContext? _dbContext)
        {
            DbContext = _dbContext;
            Subjects = new Dictionary<int, Subject>
            {
                { 0, new Subject() { Id = 0,  Name = "subject0" } },
                { 1, new Subject() { Id = 1,  Name = "subject1" } },
                { 2, new Subject() { Id = 2,  Name = "subject2" } },
                { 3, new Subject() { Id = 3,  Name = "subject3" } }
            };
            LastId = 3;
        }



        // // Memory //////////
        // public Subject AddToMemory(Subject subject)
        // {
        //     LastId++;
        //     this._subjects.Add(LastId, subject);
        //     return subject;
        // }
        //
        // public Dictionary<int, Subject> MemoryFindAll()
        // {
        //     return this._subjects;
        // }
        //
        // public Subject MemoryDelete(int subjectId)
        // {
        //     Subject result = _subjects[subjectId];
        //     _subjects.Remove(subjectId);
        //     return result;
        // }
        //
        // public Subject MemoryFindById(int subjectId)
        // {
        //     return this._subjects[subjectId];
        // }



        // DB ///////////////
        public void SetDbContext(AppDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public Task Add(Subject t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subject>> FindAll()
        {
            return await DbContext.Subjects.ToListAsync();
        }

        public Task<Subject> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Subject t)
        {
            throw new NotImplementedException();
        }
    }
}
