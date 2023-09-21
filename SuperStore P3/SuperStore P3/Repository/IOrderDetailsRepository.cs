using Models;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetail>
    {
        OrderDetail GetById(int id);

        IEnumerable<OrderDetail> GetAll();
        IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> expression);

        void Add(OrderDetail entity);                       //Add
        void AddRange(IEnumerable<OrderDetail> entities);

        void Remove(OrderDetail entity);                    //Remove
        void RemoveRange(IEnumerable<OrderDetail> entities);

        void Update(OrderDetail entity);        //Update changes made
    }
}
