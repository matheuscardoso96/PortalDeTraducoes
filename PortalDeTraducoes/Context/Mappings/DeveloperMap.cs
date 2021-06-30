using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class DeveloperMap : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developer");
            builder.Property(d => d.ImageUrl).HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(d => d.Name).HasColumnType("varchar(100)")
                .IsRequired();
           

            builder.HasIndex(d => d.Name)
                .HasDatabaseName("IX_Developer_Name");
        

            builder.HasData(new Developer("Capcom","",1));

        }
    }
}
