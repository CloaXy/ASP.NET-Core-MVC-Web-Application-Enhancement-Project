using Data;
using Models;
using SQLitePCL;
using System.Collections;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class CustomersRepository : GenericRepository<Customer>, ICustomersRepository
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();
        public CustomersRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }


        public Customer GetById(int id)
        {
            return _context.Set<Customer>().Find(id);
        }


        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }


        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> expression)
        {
            return _context.Set<Customer>().Where(expression);
        }


        public void Add(Customer entity) //Add a new customer entity
        {
            _context.Set<Customer>().Add(entity);
        }


        public void AddRange(IEnumerable<Customer> entities) //Add entities
        {
            _context.Set<Customer>().AddRange(entities);
        }


        public void Remove(Customer entity) //Remove a customer entity
        {
            _context.Set<Customer>().Remove(entity);
        }


        public void RemoveRange(IEnumerable<Customer> entities) //Remve entities
        {
            _context.Set<Customer>().RemoveRange(entities);
        }


        public void Update(Customer entity) //Update the changes made
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity cannot be null");
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
