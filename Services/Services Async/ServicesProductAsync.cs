using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services_Async
{
    class ServicesProductAsync : ServicesProduct,IServicesAsync<Product>
    {
        public async Task<Product> Add(Product o)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Add(o);
            });
        }

        public async Task<Product> GetAsync(int id)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Get(id);
            });
        }

        public async Task<List<Product>> GetAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Get();
            });
        }

        public async Task<Product> Update(Product o)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Update(o);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                base.Delete(id);
            });
        }
    }
}
