using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain.Models;

namespace WebApp.Infrastructure.EntityTypes
{
    internal class DeliveryPointEntityTypeConfiguration : BaseEntityTypeConfiguration<DeliveryPoint>
    {
        public override void Configure(EntityTypeBuilder<DeliveryPoint> builder)
        {
            builder.ToTable("DeliveryPoint");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("DeliveryPointID");

            builder.HasOne(o => o.Warehouse);

            builder.Property(o => o.Name).IsRequired();

            builder.HasIndex(i => i.Name).HasFilter("[IsDeleted] = 0");
            builder.HasIndex(i => i.Id).IsUnique().HasFilter("[IsDeleted] = 0");

            base.Configure(builder);
        }
    }
}