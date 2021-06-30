using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class TranslationImageMap : IEntityTypeConfiguration<TranslationImage>
    {
        public void Configure(EntityTypeBuilder<TranslationImage> builder)
        {
            builder.ToTable("TranslationImage");
            builder.Property(d => d.Url).HasColumnType("varchar(N)")
                .IsRequired();         
            builder.HasIndex(d => d.Url)
                .HasDatabaseName("IX_TranslationImage_Url");

        }
    }
}