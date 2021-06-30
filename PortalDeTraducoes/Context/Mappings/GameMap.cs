using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");
            builder.Property(d => d.Title).HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(d => d.ReleaseDate).HasColumnType("DateTime")
                .IsRequired();
            builder.HasIndex(d => d.Title)
                .HasDatabaseName("IX_Game_Title");

        

        }
    }
}

