using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");
            builder.Property(d => d.EmojiFlag).HasColumnType("varchar(5)")
                .IsRequired();
            builder.Property(d => d.Name).HasColumnType("varchar(30)")
                .IsRequired();

            builder.HasData(new Language(1,"Português Brasileiro", "🇧🇷"));
            builder.HasData(new Language(2,"Português de Portugal", "🇵🇹"));
            builder.HasData(new Language(3, "Espanhol", "🇪🇦"));
            builder.HasData(new Language(4, "Inglês EUA", "🇺🇸"));

        }
    }
}