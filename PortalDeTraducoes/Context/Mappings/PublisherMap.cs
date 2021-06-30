using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class PublisherMap : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("Publisher");
            builder.Property(d => d.ImageUrl).HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(d => d.Name).HasColumnType("varchar(100)")
                .IsRequired();
            builder.HasIndex(d => d.Name)
                .HasDatabaseName("IX_Platform_Name");

            builder.HasData(new Publisher("Capcom", "",1));

        }
    }
}
