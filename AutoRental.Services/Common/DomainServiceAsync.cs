using AutoRental.Data.Common;
using AutoRental.Data.Model.Common;
using Services.Services_Async;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRental.Services.Common
{
    public abstract class DomainServiceAsync<T> : IServicesAsync<T> where T : BaseModel
	    {
	        protected readonly IRepository<T> repository;
	
	        public DomainServiceAsync(IRepository<T> repository)
		        {
	            this.repository = repository;
	
	        }
	        public async Task<T> AddAsync(T entity)
	        {
	            return await this.repository.AddAsync(entity);
	        }
	
	        public async Task<T> GetAsync(int id)
	        {
	            return await this.repository.GetAsync(id);
	        }
	
	        public async Task<List<T>> GetAsync()
	        {
	            return await this.repository.GetAsync();
	        }
	
	        public async Task<T> UpdateAsync(T entity)
	        {
	            return await this.repository.UpdateAsync(entity);
	        }
	
	        public async Task DeleteAsync(int id)
	        {
	            await this.repository.DeleteAsync(id);
	        }
	    }
}
