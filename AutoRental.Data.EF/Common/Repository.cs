using AutoRental.Data.Common;
using AutoRental.Data.Model.Common;
using System.Threading.Tasks;

namespace AutoRental.Data.EF.Common
{
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T> where T : BaseModel
    {
        public Repository(DataContext context):base(context)
        {

        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var addedEntity = base.Set.Add(entity);
            await base.Context.SaveChangesAsync();
            return addedEntity;
            
        }

        public virtual async Task DeleteAsync(int id)
        {
            base.Set.Remove(base.GetAsync(id).Result);
            await base.Context.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (Context.Entry(entity).State == System.Data.Entity.EntityState.Added)
            {
                return entity;
            }

            base.Set.Attach(entity);
            base.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            await base.Context.SaveChangesAsync();

            return entity;
        }
    }
}
