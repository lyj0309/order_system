namespace Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        List<T> GetAll();
        T GetByNameAndPass(string name, string pass);
        T GetById(Guid id);
        void Delete(Guid id);
    }
}
