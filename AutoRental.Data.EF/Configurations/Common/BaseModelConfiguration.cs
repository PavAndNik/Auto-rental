using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Entity.ModelConfiguration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF.Configurations.Common
{
    public abstract class BaseModelConfiguration<T> : EntityTypeConfiguration<T> where T :BaseModel
    {
        private static readonly PluralizationService PluralizationService =
            PluralizationService.CreateService(new CultureInfo("en-US"));

        public BaseModelConfiguration()
        {
            ToTable(GetTableName());

            HasKey(m => m.Id).Property(p => p.Id).HasColumnName(GetKeyName()).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private string GetTableName()
        {
            var typeName = typeof(T).Name;

            return PluralizationService.Pluralize(typeName);
        }

        private string GetKeyName()
        {
            return string.Format("{0}Id", typeof(T).Name);
        }
    }
}
