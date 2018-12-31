using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
   public class ProductCategoryRepository
    {
       ObjectCache cache = MemoryCache.Default;
       private List<ProductCategory> productsCategories;

       public ProductCategoryRepository()
       {
           productsCategories = cache["productCategory"] as List<ProductCategory>;
           if (productsCategories == null)
           {
               productsCategories = new List<ProductCategory>();
           }
       }

       public void Commit()
       {
           cache["productCategory"] = productsCategories;
       }

       public void Insert(ProductCategory p)
       {
           productsCategories.Add(p);
       }

       public void Update(ProductCategory productsCategory)
       {
           ProductCategory productCategoryToUpdate = productsCategories.Find(p => p.Id == productsCategory.Id);

           if (productCategoryToUpdate != null)
           {
               productCategoryToUpdate = productsCategory;
           }
           else
           {
               throw new Exception("Product Category Not Found");
           }
       }

       public ProductCategory Find(string Id)
       {
           ProductCategory productCategory = productsCategories.Find(p => p.Id == Id);

           if (productCategory != null)
           {
               return productCategory;
           }
           else
           {
               throw new Exception("Product Category Not Found");
           }

       }

       public IQueryable<ProductCategory> Collection()
       {
           return productsCategories.AsQueryable();
       }

       public void Delete(string Id)
       {
           ProductCategory productCategoryToDelete = productsCategories.Find(p => p.Id == Id);

           if (productCategoryToDelete != null)
           {
               productsCategories.Remove(productCategoryToDelete);
           }
           else
           {
               throw new Exception("ProductCategory Not Found");
           }

       }
   }
}
