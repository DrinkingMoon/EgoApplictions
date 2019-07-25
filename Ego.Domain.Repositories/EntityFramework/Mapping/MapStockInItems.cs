using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework.Mapping
{
    public class MapStockInItems : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Model.StockInItem>
    {

        public MapStockInItems()
        {
            HasKey<Guid>(k => k.ID);
            Property(p => p.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasOptional(k => k.StockInBill).WithMany(l => l.StockInItems);
        }
    }
}
