using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRUDWITHJSONINWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProduct" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceProduct.svc or ServiceProduct.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProduct : IServiceProduct
    {
        private dbMilePointEntities dbContext;
        public ServiceProduct()
        { }
        public ServiceProduct(dbMilePointEntities obj)
        { this.dbContext = obj; }
        public bool create(Product product)
        {
            try {
                ProductEntity pe = new ProductEntity();
                pe.Name = product.Name;
                pe.Price = product.Price;
                pe.Quantity = pe.Quantity;
                dbContext.ProductEntities.Add(pe);
                dbContext.SaveChanges();
                return true;
            }
            catch {
                return false; }

        }
        public bool edit(Product product)
        {
            try
            {
                int id = Convert.ToInt32(product.Id);
                ProductEntity pe = dbContext.ProductEntities.Single(p => p.Id == product.Id);
                pe.Name = product.Name;
                pe.Price = product.Price;
                pe.Quantity = pe.Quantity;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(Product product)
        {
            try {
                int id = Convert.ToInt32(product.Id);
                ProductEntity pe = dbContext.ProductEntities.Single(p => p.Id == product.Id);
                dbContext.ProductEntities.Remove(pe);
                dbContext.SaveChanges();

                return true; }
            catch { return false; }

        }

        //https://www.youtube.com/watch?v=EZJWubzKA8Y

        public List<Product> findall()
        {
            using (dbMilePointEntities dbcontext = new dbMilePointEntities()) {
                return dbcontext.ProductEntities.Select(p => new Product {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    Quantity=p.Quantity.Value           

                }).ToList();
            };
        }

        public Product find(string  id)
        {
            int nid = Convert.ToInt32(id);
            return dbContext.ProductEntities.Where(p => p.Id == nid).Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price.Value,
                Quantity = p.Quantity.Value
            }).First();
            
        }
    }
}
