using System.Linq.Expressions;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null); 
        T GetById(int id);  
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);  // Soft Delete
        void Save();
    }
}
