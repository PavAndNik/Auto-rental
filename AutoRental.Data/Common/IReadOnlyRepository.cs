using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.Common
{
   public interface IReadOnlyRepository<T> where T :BaseModel
    {
        Task<T> GetAsync(int id);

        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter = null);
    }
}
