using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Core.Entities;

namespace Weelo.Infrastructure.Mapping
{
    class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> modelBuilder)
        {
            modelBuilder.ToTable("Owners");
            modelBuilder.HasKey(i => i.IdOwner);
            modelBuilder.Property(p => p.Name).HasMaxLength(50).IsRequired(true);
            modelBuilder.Property(p => p.Address).HasMaxLength(100).IsRequired(true);
            modelBuilder.Property(p => p.Photo).IsRequired(false);
            modelBuilder.Property(p => p.Birthday).IsRequired(true);
            modelBuilder.Property(p => p.Active).HasDefaultValue(true).IsRequired(true);
            modelBuilder.Property(p => p.Deleted).HasDefaultValue(false).IsRequired(true);

            modelBuilder.HasMany(i => i.Properties)
                .WithOne(i => i.Owner)
                .HasForeignKey(i => i.IdOwner).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(i => i.IdOwner);

        }
    }
}
