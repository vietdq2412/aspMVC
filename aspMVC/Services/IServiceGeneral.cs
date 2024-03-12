namespace aspMVC.Services
{
    public interface IServiceGeneral<T>
    {
        Task<List<T>> FindAll();
        Task<T> FindById(int id);
        Task<T> FindByName(string name);

        Task Add(T t);
        Task Update(T t);
        Task Delete(int id);

        // //memory
        // T AddToMemory(T entity);
        // Dictionary<int, T> MemoryFindAll();
        // T MemoryDelete(int id);
        // T MemoryFindById(int id);
    }
}
