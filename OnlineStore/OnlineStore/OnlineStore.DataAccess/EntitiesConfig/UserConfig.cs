using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.EntitiesConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PaswordHashed).IsRequired().HasMaxLength(1000);

            builder.HasOne(x => x.UserRole)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.UserRoleId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_User_UserRole");

            builder.HasIndex(x => x.Email).IsUnique();

        }
    }
}
