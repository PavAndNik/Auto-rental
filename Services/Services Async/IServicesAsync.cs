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
        Task<T> Add(T o);
        Task<T> Update(T o);
        Task Delete(int id);
    }
}
