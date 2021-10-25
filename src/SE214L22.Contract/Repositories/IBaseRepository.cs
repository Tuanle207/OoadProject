using SE214L22.Contract.Entities;

namespace SE214L22.Contract.Repositories
{
    public interface IBaseRepository<T> where T : AppEntity
    {
        T Create(T entity);
        bool Delete(int id);
        T Get(int id);
        bool Update(T entity);
    }
}