using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework.Mapping
{
    public class StockInItemsTypeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Model.StockInItems>
    {

        public StockInItemsTypeConfiguration()
        {
            HasKey<Guid>(k => k.ID);
            Property(p => p.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasOptional(k => k.StockInBill).WithMany(l => l.DetailItems);
        }
    }
}
