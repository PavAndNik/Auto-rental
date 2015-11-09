using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServicesProduct
    {
        private static List<Product> listOfProduct = new List<Product>();

        public Product Get(int id)
        {
            return (Product)listOfProduct.SingleOrDefault(item => item.Id == id).Clone();
        }

        public List<Product> Get()
        {
            return listOfProduct;
        }

        public Product Add(Product ProductForAdd)
        {
            ProductForAdd.Id = listOfProduct.Any() ? listOfProduct.Max(item => item.Id) + 1 : 1;
            listOfProduct.Add(ProductForAdd);
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

            return (Product)product.Clone();
        }

        public void Delete(int id)
        {
            var product = this.Get(id);
            if (product == null)
            {
                throw new NullReferenceException();
            }

            listOfProduct.Remove(product);
        }
    }
}
