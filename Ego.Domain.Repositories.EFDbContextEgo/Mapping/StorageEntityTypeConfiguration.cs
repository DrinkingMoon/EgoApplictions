using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EFDbContextEgo.Mapping
{
    public class StorageEntityTypeConfiguration : EntityTypeConfiguration<Storage>
    {
        public StorageEntityTypeConfiguration()
        {
            HasKey<Guid>(k => k.ID);
            Property(p => p.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
