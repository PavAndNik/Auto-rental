using AutoRental.Audit;
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
        private readonly int delay;
        public ServicesOrderAsync(IAuditManager auditManager) : this(5000, auditManager)
	        {

        }
        public ServicesOrderAsync(int delay, IAuditManager auditManager) : base(auditManager)
	        {
            this.delay = delay;
        }
        public async Task<Order> AddAsync(Order o)
        {
            await Task.Delay(delay);

            return base.Add(o);
        }

        public async Task<Order> GetAsync(int id)
        {
            await Task.Delay(delay);
            return base.Get(id);
        }

        public async Task<List<Order>> GetAsync()
        {
            await Task.Delay(delay);

            return base.Get();
        }

        public async Task<Order> UpdateAsync(Order o)
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
