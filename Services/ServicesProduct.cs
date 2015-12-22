using AutoRental.Audit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServicesProduct
    {
        private static List<Product> listOfProduct = new List<Product>();
        private readonly IAuditManager auditManager;

        public ServicesProduct(IAuditManager auditManager)
        {
            this.auditManager = auditManager;
        }
        public Product Get(int id)
        {
            foreach (Product p in listOfProduct)
                if (p.Id == id) return (Product)p.Clone();
            this.auditManager.Access(typeof(Product), AccessType.Read);
            return null;
        }

        public List<Product> Get()
        {
            this.auditManager.Access(typeof(Product), AccessType.Read);
            return listOfProduct;
        }

        public Product Add(Product ProductForAdd)
        {
            ProductForAdd.Id = listOfProduct.Any() ? listOfProduct.Max(item => item.Id) + 1 : 1;
            listOfProduct.Add(ProductForAdd);
            this.auditManager.Access(typeof(Product), AccessType.Add);
            return (Product)ProductForAdd.Clone();
        }

        public Product Update(Product productForUpdate)
        {
            var product = this.Get(productForUpdate.Id);
            if (product == null)
            {
                throw new NullReferenceException();
            }

            product.Name = productForUpdate.Name;
            product.Price = productForUpdate.Price;
            product.Producer = productForUpdate.Producer;
            product.Type = productForUpdate.Type;
            product.Characteristics = productForUpdate.Characteristics;
            product.Cost = productForUpdate.Cost;
            product.DateOfCreation = productForUpdate.DateOfCreation;
            product.Discount = productForUpdate.Discount;

            this.auditManager.Access(typeof(Product), AccessType.Update);

            return (Product)product.Clone();
        }

        public void Delete(int id)
        {
            Product product = listOfProduct.SingleOrDefault(item => item.Id == id);
            if (product == null) throw new NullReferenceException();
            listOfProduct.Remove(product);
            this.auditManager.Access(typeof(Product), AccessType.Delete);
        }
    }
}
