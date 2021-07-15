using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ToTable("User");
            //builder.Property(d => d.NickName).HasColumnType("varchar(90)")
            //    .IsRequired();
            //builder.Property(d => d.Country).HasColumnType("varchar(90)");
            //builder.Property(d => d.State).HasColumnType("varchar(90)");
            //builder.Property(d => d.City).HasColumnType("varchar(90)");
            //builder.Property(d => d.Password).HasColumnType("varchar(30)")
            //.IsRequired();

            builder.HasDiscriminator().HasValue("User");

            //builder.HasOne(g => g.Group).WithMany(u => u.Users).OnDelete(DeleteBehavior.NoAction);
           

            //builder.HasIndex(d => d.NickName)
            //        .HasDatabaseName("IX_User_NickName");

        }
    }
}


