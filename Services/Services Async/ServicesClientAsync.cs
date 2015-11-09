﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services_Async
{
    class ServicesClientAsync : ServicesClient, IServicesAsync
    {
        public async Task<Client> Add(Client o)
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

        public async Task<List<Client>> GetListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Get();
            });
        }

        public async Task<Client> Update(Client o)
        {
            return await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return base.Update(o);
            });
        }

        public async void Delete(int id)
        {
            await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                base.Delete(id);
            });
        }

    }
}
