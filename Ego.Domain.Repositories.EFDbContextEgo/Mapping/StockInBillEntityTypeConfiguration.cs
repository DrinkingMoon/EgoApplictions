using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EFDbContextEgo.Mapping
{
    public class StockInBillEntityTypeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Model.StockInBill>
    {

        public StockInBillEntityTypeConfiguration()
        {
            HasKey<Guid>(k => k.ID);
            Property(p => p.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
