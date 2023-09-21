using Data;
using Models;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();
        public OrdersRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }


        public Order GetById(int id)
        {
            return _context.Set<Order>().Find(id);
        }


        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }


        public IEnumerable<Order> Find(Expression<Func<Order, bool>> expression)
        {
            return _context.Set<Order>().Where(expression);
        }


        public void Add(Order entity) //Add new order
        {
            _context.Set<Order>().Add(entity);
        }


        public void AddRange(IEnumerable<Order> entities) //Add more than one order
        {
            _context.Set<Order>().AddRange(entities);
        }


        public void Remove(Order entity) //Remove an order
        {
            _context.Set<Order>().Remove(entity);
        }


        public void RemoveRange(IEnumerable<Order> entities) //Remove more than one order
        {
            _context.Set<Order>().RemoveRange(entities);
        }


        public void Update(Order entity) //Update changes made
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
                throw new Exception($"{nameof(entity)} was not able to be updated: {ex.Message}");
            }
        }
    }
}
