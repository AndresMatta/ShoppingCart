using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using ShoppingCart.Core.Models;

namespace ShoppingCart.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if (productToUpdate == null)
            {
                throw new Exception("Product not found");
            }

            productToUpdate = product;
        }

        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return product;
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete == null)
            {
                throw new Exception("Product not found");
            }

            products.Remove(productToDelete);

        }
    }
}
