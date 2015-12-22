using AutoRental.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services_Async
{
   public class ServicesProductAsync : ServicesProduct,IServicesAsync<Product>
    {
        private readonly int delay;
        public ServicesProductAsync(IAuditManager auditManager) : this(5000, auditManager)
	        {

        }
        public ServicesProductAsync(int delay, IAuditManager auditManager) : base(auditManager)
	        {
            this.delay = delay;
        }
        public async Task<Product> AddAsync(Product o)
        {
            await Task.Delay(delay);

            return base.Add(o);
        }

        public async Task<Product> GetAsync(int id)
        {
            await Task.Delay(delay);
            return base.Get(id);
        }

        public async Task<List<Product>> GetAsync()
        {
            await Task.Delay(delay);

            return base.Get();
        }

        public async Task<Product> UpdateAsync(Product o)
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
