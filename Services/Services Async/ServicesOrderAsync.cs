using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services_Async
{
    public class ServicesOrderAsync : ServicesOrder, IServicesAsync<Order>
    {
        public async Task<Order> AddAsync(Order o)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Add(o);
            });
        }

        public async Task<Order> GetAsync(int id)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Get(id);
            });
        }

        public async Task<List<Order>> GetAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Get();
            });
        }

        public async Task<Order> UpdateAsync(Order o)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Update(o);
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                base.Delete(id);
            });
        }
    }
}
