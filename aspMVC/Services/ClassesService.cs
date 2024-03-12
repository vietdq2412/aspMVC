using aspMVC.Data;
using aspMVC.Models;

namespace aspMVC.Services
{
    public interface IClassesService : IServiceGeneral<Classes>
    {
        Classes FindByName(string name);
    }
    public class ClassesService:IClassesService
    {
        public AppDbContext DbContext { get; }
        public Dictionary<int, Classes> Classes { get; }
        public int IdIncreament { get; set; }
        
        private static ClassesService? _instance;
        
        public static ClassesService? GetInstance(AppDbContext appDbContext)
        {
            return _instance = _instance ?? new ClassesService(appDbContext);
        }
        
        private ClassesService(AppDbContext appDbContext)
        {
            this.DbContext = appDbContext;
            Classes = new Dictionary<int, Classes>
            {
                { 0, new Classes() { Id = 0,  Name = "A1" } },
                { 1, new Classes() { Id = 1,  Name = "A2" } },
                { 2, new Classes() { Id = 2,  Name = "B1" } },
                { 3, new Classes() { Id = 3,  Name = "B2" } }
            };
            IdIncreament = 3;
        }
        
        
        // Memory //////////
        public Classes AddToMemory(Classes subject)
        {
            IdIncreament++;
            subject.Id = IdIncreament;
            this.Classes.Add(IdIncreament, subject);
            return subject;
        }
        
        public Dictionary<int, Classes> MemoryFindAll()
        {
            return this.Classes;
        }
        
        public Classes MemoryDelete(int subjectId)
        {
            Classes result = Classes[subjectId];
            Classes.Remove(subjectId);
            return result;
        }
        
        public Classes MemoryFindById(int subjectId)
        {
            return this.Classes[subjectId];
        }

        Classes IClassesService.FindByName(string name)
        {
            throw new NotImplementedException();
        }

        // DB
        public Task<List<Classes>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Classes> FindById(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Classes> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Add(Classes t)
        {
            throw new NotImplementedException();
        }

        public Task Update(Classes t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
