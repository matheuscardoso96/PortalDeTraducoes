using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{
    public class PlatformMap : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.ToTable("Platform");
            builder.Property(d => d.ImageUrl).HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(d => d.Name).HasColumnType("varchar(30)")
                .IsRequired();
			builder.HasIndex(d => d.Name)
				.HasDatabaseName("IX_Platform_Name");

			builder.HasData(new Platform("Atari", "",1));
			builder.HasData(new Platform("Colecovision", "",2));
			builder.HasData(new Platform("SG-1000", "",3));
			builder.HasData(new Platform("NES", "",4));
			builder.HasData(new Platform("Famicom Disk System", "",5));
			builder.HasData(new Platform("PC Engine", "",6));
			builder.HasData(new Platform("Master System", "",7));
			builder.HasData(new Platform("SNES", "",8));
			builder.HasData(new Platform("Mega Drive", "",9));
			builder.HasData(new Platform("Sega 32X", "",10));
			builder.HasData(new Platform("Sega CD", "",11));
			builder.HasData(new Platform("Game Gear", "",12));
			builder.HasData(new Platform("Game Boy", "",13));
			builder.HasData(new Platform("Nintendo 64", "",14));
			builder.HasData(new Platform("Playstation", "",15));
			builder.HasData(new Platform("Sega Saturn", "",16));
			builder.HasData(new Platform("Atari Jaguar", "",17));
			builder.HasData(new Platform("Game Boy Color", "",18));
			builder.HasData(new Platform("3DO", "",19));
			builder.HasData(new Platform("WonderSwan", "",20));
			builder.HasData(new Platform("WonderSwan Color", "",21));
			builder.HasData(new Platform("Dreamcast", "",22));
			builder.HasData(new Platform("Game Boy Advance", "",23));
			builder.HasData(new Platform("Playstation 2", "",24));
			builder.HasData(new Platform("Game Cube ", "",25));
			builder.HasData(new Platform("Xbox", "",26));
			builder.HasData(new Platform("PSP", "",27));
			builder.HasData(new Platform("Nintendo DS", "",28));
			builder.HasData(new Platform("Xbox 360", "",29));
			builder.HasData(new Platform("Wii", "",30));
			builder.HasData(new Platform("Playstation 3", "",31));
			builder.HasData(new Platform("Dingoo", "",32));
			builder.HasData(new Platform("PSVITA", "",33));
			builder.HasData(new Platform("3DS", "",34));
			builder.HasData(new Platform("Wii U", "",35));
			builder.HasData(new Platform("Playstation 4", "",36));
			builder.HasData(new Platform("Nintendo Switch", "",37));
			builder.HasData(new Platform("Java - Celular", "",38));
			builder.HasData(new Platform("Android", "",39));



		}
    }
}