using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain.Models;

namespace WebApp.Infrastructure.EntityTypes
{
    internal class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("UserID");

            builder.HasOne(u => u.Company);

            builder.HasIndex(i => i.NormalizedUserName).IsUnique().HasFilter("[IsDeleted] = 0");
            builder.HasIndex(i => i.UserName).IsUnique().HasFilter("[IsDeleted] = 0");

            base.Configure(builder);
        }
    }
}