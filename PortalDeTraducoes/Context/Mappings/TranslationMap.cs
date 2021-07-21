using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class TranslationMap : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.ToTable("Translation");
            builder.HasOne(p => p.Game).WithMany(p => p.Translations)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Group).WithMany(p => p.Translations)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}