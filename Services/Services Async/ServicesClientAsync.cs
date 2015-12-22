using AutoRental.Audit;
using Services.Services_Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services_Async
{
   public class ServicesClientAsync : ServicesClient, IServicesAsync<Client>
    {
        private readonly int delay;
        public ServicesClientAsync(IAuditManager auditManager) : this(5000, auditManager)
	        {
	
	        }
        public ServicesClientAsync(int delay, IAuditManager auditManager) : base(auditManager)
	        {
	            this.delay = delay;
	        }
    public async Task<Client> AddAsync(Client o)
        {
            await Task.Delay(delay);
            
              return base.Add(o);
        }

        public async Task<Client> GetAsync(int id)
        {
            await Task.Delay(delay);
            return base.Get(id);
        }

        public async Task<List<Client>> GetAsync()
        {
            await Task.Delay(delay);

             return base.Get();
        }

        public async Task<Client> UpdateAsync(Client o)
        {
            await Task.Delay(delay);
           
             return base.Update(o);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(delay);
            base.Delete(id);
        }

    }
}
