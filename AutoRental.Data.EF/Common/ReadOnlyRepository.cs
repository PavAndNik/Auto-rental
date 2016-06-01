using AutoRental.Data.Common;
using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF.Common
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : BaseModel
    {
        protected readonly DataContext Context;

        public ReadOnlyRepository(DataContext context)
        {
            this.Context = context;
        }

        protected DbSet<T> Set
        {
            get { return this.Context.Set<T>(); }
        }

        public virtual async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter = null)
        {
            return await Task.FromResult((filter == null?  Set : Set.Where(filter)).ToList());
        }

        public virtual async Task<T> GetAsync(int id)     
        {
            return await Task.FromResult(Set.FirstOrDefault(e => e.Id == id));
        }
    }
}
