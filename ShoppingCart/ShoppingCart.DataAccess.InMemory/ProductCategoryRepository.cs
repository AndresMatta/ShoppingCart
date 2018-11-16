using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using ShoppingCart.Core.Models;

namespace ShoppingCart.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory categoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

            if (categoryToUpdate == null)
            {
                throw new Exception("Category not found");
            }

            categoryToUpdate = productCategory;
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory category = productCategories.Find(p => p.Id == Id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            return category;
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory categoryToDelete = productCategories.Find(p => p.Id == Id);

            if (categoryToDelete == null)
            {
                throw new Exception("Category not found");
            }

            productCategories.Remove(categoryToDelete);

        }
    }
}
