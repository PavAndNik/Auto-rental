using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF.Configurations.Common
{
    public abstract class BaseModelConfiguration<T> : EntityTypeConfiguration<T> where T :BusinesObject
    {
        public BaseModelConfiguration()
        {
            ToTable(GetTableName());

            HasKey(m => m.Id).Property(p => p.Id).HasColumnName(GetKeyName());
        }

        private string GetTableName()
        {
            var typeName = typeof(T).Name;

            if(typeName.EndsWith("s"))
            {
                return string.Format("{0}es", typeName);
            }
            return string.Format("{0}s", typeName);
        }

        private string GetKeyName()
        {
            return string.Format("{0}Id", typeof(T).Name);
        }
    }
}
