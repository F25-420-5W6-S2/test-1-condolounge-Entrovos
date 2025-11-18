namespace CondoLounge.Data.Interfaces
{
    public interface ICondoLoungeGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetOneById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool SaveAll();
    }
}
