using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services_Async
{
    interface IServicesAsync<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T o);
        Task<T> UpdateAsync(T o);
        Task DeleteAsync(int id);
    }
}
