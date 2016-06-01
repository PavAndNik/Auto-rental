using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.Common
{

    public interface IRepository<T> :IReadOnlyRepository<T> where T : BaseModel
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
