using AutoRental.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF.Common
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : BusinesObject
    {
        protected readonly DataContext context;

        public ReadOnlyRepository(DataContext context)
        {
            this.context = context;
        }

        protected DbSet<T> Set
        {
            get { return this.context.Set<T>(); }
        }

        public virtual async Task<List<T>> GetAsync()
        {
            return await Task.FromResult(Set.ToList());
        }

        public virtual async Task<T> GetAsync(int id)     
        {
            return await Task.FromResult(Set.FirstOrDefault(e => e.Id == id));
        }
    }
}
