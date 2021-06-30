using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");
            builder.Property(d => d.ImageUrl).HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(d => d.Name).HasColumnType("varchar(100)")
                .IsRequired();
            builder.HasIndex(d => d.Name)
                .HasDatabaseName("IX_Group_Name");

           // builder.HasData(new Developer("Capcom", "",1));

        }
    }
}