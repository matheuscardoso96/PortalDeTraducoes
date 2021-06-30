using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeTraducoes.Models.Entities;

namespace PortalDeTraducoes.Context.Mappings
{

    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");
            builder.Property(d => d.Name).HasColumnType("varchar(50)")
                .IsRequired();
            builder.HasIndex(d => d.Name)
                .HasDatabaseName("IX_Genre_Name");

            builder.HasData(new Genre("Ação",1));
            builder.HasData(new Genre("Aventura", 2));
            builder.HasData(new Genre("Casual", 3));
            builder.HasData(new Genre("Simulador", 4));
            builder.HasData(new Genre("Estratégia", 5));
            builder.HasData(new Genre("RPG", 6));
            builder.HasData(new Genre("Multijogador", 7));
            builder.HasData(new Genre("3D", 8));
            builder.HasData(new Genre("Esporte", 9));
            builder.HasData(new Genre("Quebra-Cabeças", 10));
            builder.HasData(new Genre("Fantasia", 11));
            builder.HasData(new Genre("Corrida", 12));
            builder.HasData(new Genre("Anime", 13));
            builder.HasData(new Genre("Primeira Pessoa", 14));
            builder.HasData(new Genre("Terceira Pessoa", 15));
            builder.HasData(new Genre("Ficção Científica", 16));
            builder.HasData(new Genre("Arcade", 17));
            builder.HasData(new Genre("Terror", 18));
            builder.HasData(new Genre("Retro", 19));
            builder.HasData(new Genre("Educativo", 20));
            builder.HasData(new Genre("Jogo de Tabuleiro", 21));
            builder.HasData(new Genre("Co-op", 22));
            builder.HasData(new Genre("Mundo Aberto", 23));
            builder.HasData(new Genre("Plataformas", 24));
            builder.HasData(new Genre("Realidade Virtual", 25));
            builder.HasData(new Genre("Sobrevivência", 26));
            builder.HasData(new Genre("Ação/Aventura", 27));
            builder.HasData(new Genre("Tiro", 28));
            builder.HasData(new Genre("Romance Visual", 29));
            builder.HasData(new Genre("Point & Click", 30));
            builder.HasData(new Genre("Plataforma", 31));
            builder.HasData(new Genre("RPG de Ação", 32));
            builder.HasData(new Genre("JRPG", 33));


        }
    }
}
