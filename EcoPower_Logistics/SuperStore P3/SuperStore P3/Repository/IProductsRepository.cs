using Models;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface IProductsRepository
    {
        Product GetById(int id);

        IEnumerable<Product> GetAll();
        IEnumerable<Product> Find(Expression<Func<Product, bool>> expression);

        void Add(Product entity);                       //Add
        void AddRange(IEnumerable<Product> entities);

        void Remove(Product entity);                    //Remove
        void RemoveRange(IEnumerable<Product> entities);

        void Update(Product entity);            //Update changes made
    }
}
