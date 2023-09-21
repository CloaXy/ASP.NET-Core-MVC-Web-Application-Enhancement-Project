using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entity);                     //Add
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);                      //Remove
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);              //Update changes made
    }
}
