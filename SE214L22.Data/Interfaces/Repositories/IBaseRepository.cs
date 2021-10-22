using SE214L22.Data.Entity;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : AppEntity
    {
        T Create(T entity);
        bool Delete(int id);
        T Get(int id);
        bool Update(T entity);
    }
}