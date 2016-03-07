using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.Common
{
   public interface IReadOnlyRepository<T> where T :BusinesObject
    {
        Task<T> GetAsync(int id);

        Task<List<T>> GetAsync();
    }
}
