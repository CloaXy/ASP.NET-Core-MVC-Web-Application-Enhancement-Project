using Models;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface IOrdersRepository
    {
        Order GetById(int id);

        IEnumerable<Order> GetAll();
        IEnumerable<Order> Find(Expression<Func<Order, bool>> expression);

        void Add(Order entity);                         //Add
        void AddRange(IEnumerable<Order> entities);

        void Remove(Order entity);                      //Remove
        void RemoveRange(IEnumerable<Order> entities);

        void Update(Order entity);              //Update changes made
    }
}
