using Data;
using System.Linq.Expressions;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailsRepository
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();
        public OrderDetailsRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }


        public OrderDetail GetById(int id)
        {
            return _context.Set<OrderDetail>().Find(id);
        }


        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.Set<OrderDetail>().ToList();
        }


        public IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> expression)
        {
            return _context.Set<OrderDetail>().Where(expression);
        }


        public void Add(OrderDetail entity) //Add new order details
        {
            _context.Set<OrderDetail>().Add(entity);
        }


        public void AddRange(IEnumerable<OrderDetail> entities) //Add order details of a range
        {
            _context.Set<OrderDetail>().AddRange(entities);
        }


        public void Remove(OrderDetail entity) //Remove order details
        {
            _context.Set<OrderDetail>().Remove(entity);
        }


        public void RemoveRange(IEnumerable<OrderDetail> entities) //Remove order details of a range
        {
            _context.Set<OrderDetail>().RemoveRange(entities);
        }


        public void Update(OrderDetail entity) //Update changes made in order details
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} cannot be null");
            }
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} was unable to be updated: {ex.Message}");
            }
        }
    }
}
