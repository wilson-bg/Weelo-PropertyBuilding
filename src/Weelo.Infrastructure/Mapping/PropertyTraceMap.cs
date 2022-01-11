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

    class PropertyTraceMap : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> modelBuilder)
        {
            modelBuilder.ToTable("PropertyTraces");
            modelBuilder.HasKey(i => i.IdPropertyTrace);
            modelBuilder.Property(p => p.DateSale).HasColumnType("Date").IsRequired(true);
            modelBuilder.Property(p => p.Name).HasMaxLength(50).IsRequired(true);
            modelBuilder.Property(p => p.Value).IsRequired(true);
            modelBuilder.Property(p => p.Tax).IsRequired(true);

            modelBuilder.HasOne(i => i.Property)
               .WithMany(i => i.Traces)
               .HasForeignKey(i => i.IdProperty).OnDelete(DeleteBehavior.NoAction)
               .HasPrincipalKey(i => i.IdProperty);

        }
    }
}
