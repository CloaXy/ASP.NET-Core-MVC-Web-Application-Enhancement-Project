using Data;
using Models;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();
        public ProductsRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }


        public Product GetById(int id)
        {
            return _context.Set<Product>().Find(id);
        }


        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }


        public IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return _context.Set<Product>().Where(expression);
        }


        public void Add(Product entity) //Add a product
        {
            _context.Set<Product>().Add(entity);
        }


        public void AddRange(IEnumerable<Product> entities) //Add more than one product
        {
            _context.Set<Product>().AddRange(entities);
        }

        public void Remove(Product entity) //Remove product
        {
            _context.Set<Product>().Remove(entity);
        }


        public void RemoveRange(IEnumerable<Product> entities) //Remove more than one product
        {
            _context.Set<Product>().RemoveRange(entities);
        }


        public void Update(Product entity) //Update the changes made
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} cannont be null");
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
