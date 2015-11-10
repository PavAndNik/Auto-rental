using Services.Services_Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services_Async
{
    class ServicesClientAsync : ServicesClient, IServicesAsync<Client>
    {
        public async Task<Client> AddAsync(Client o)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Add(o);
            });
        }

        public async Task<Client> GetAsync(int id)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000); 
                return base.Get(id);
            });
        }

        public async Task<List<Client>> GetAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Get();
            });
        }

        public async Task<Client> UpdateAsync(Client o)
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
