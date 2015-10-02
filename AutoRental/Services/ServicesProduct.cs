using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Services
{
    class ServicesProduct
    {
        private List<Product> ListOfProduct = new List<Product>();
        public void AddProduct(Product NewProduct)
        {
            NewProduct.Id = ListOfProduct.Last<Product>().Id+1;
            ListOfProduct.Add(NewProduct);
        }
        public Product GetProduct(string ID)
        {
            foreach(Product p in ListOfProduct)
            {
                if (p.Id == ID)
                    return p;
            }
            return null;
        }
        public void DeleteProduct(string ID)
        {
            foreach (Product p in ListOfProduct)
            {
                if (p.Id == ID)
                    ListOfProduct.Remove(p);
            }
        }
        public void UpdateProduct(Product P)
        {
            int index = ListOfProduct.IndexOf(P);
            if (index != -1)
            {
                ListOfProduct[index] = P;
            }
            else AddProduct(P);
        }
    }
}
