using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.Property(d => d.Description).HasColumnType("varchar(30)")
                .IsRequired();

            builder.HasIndex(d => d.Description)
                    .HasDatabaseName("IX_Role_Description");
            builder.HasData(new UserRole(1, "Administrador"));
            builder.HasData(new UserRole(2, "Moderador"));
            builder.HasData(new UserRole(3, "Usuario"));

        }
    }
}