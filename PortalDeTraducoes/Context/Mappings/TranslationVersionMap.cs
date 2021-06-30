using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class TranslationVersionMap : IEntityTypeConfiguration<TranslationVersion>
    {
        public void Configure(EntityTypeBuilder<TranslationVersion> builder)
        {
            builder.ToTable("TranslationVersion");
            builder.Property(d => d.Version).HasColumnType("varchar(20)")
                .IsRequired();
            builder.Property(d => d.DownloadLink).HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(d => d.PatchNote).HasColumnType("varchar(255)")
                .IsRequired();
            builder.HasOne(t => t.Translation).WithMany(tv => tv.TranslationVersions)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasIndex(d => d.DownloadLink)
                .HasDatabaseName("IX_TranslationVersion_DownloadLink");

        }
    }
}