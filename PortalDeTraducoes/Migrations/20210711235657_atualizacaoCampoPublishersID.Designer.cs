﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalDeTraducoes.Context;

namespace PortalDeTraducoes.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210711235657_atualizacaoCampoPublishersID")]
    partial class atualizacaoCampoPublishersID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeveloperGame", b =>
                {
                    b.Property<int>("DevelopersID")
                        .HasColumnType("int");

                    b.Property<int>("GamesID")
                        .HasColumnType("int");

                    b.HasKey("DevelopersID", "GamesID");

                    b.HasIndex("GamesID");

                    b.ToTable("DeveloperGame");
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.Property<int>("GamesID")
                        .HasColumnType("int");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.HasKey("GamesID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("GameGenre");
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.Property<int>("GamesID")
                        .HasColumnType("int");

                    b.Property<int>("PlatformsID")
                        .HasColumnType("int");

                    b.HasKey("GamesID", "PlatformsID");

                    b.HasIndex("PlatformsID");

                    b.ToTable("GamePlatform");
                });

            modelBuilder.Entity("GamePublisher", b =>
                {
                    b.Property<int>("GamesID")
                        .HasColumnType("int");

                    b.Property<int>("PublishersID")
                        .HasColumnType("int");

                    b.HasKey("GamesID", "PublishersID");

                    b.HasIndex("PublishersID");

                    b.ToTable("GamePublisher");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Developer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Developer_Name");

                    b.ToTable("Developer");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ImageUrl = "",
                            Name = "Capcom"
                        });
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.HasIndex("Title")
                        .HasDatabaseName("IX_Game_Title");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Genre_Name");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Ação"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Aventura"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Casual"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Simulador"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Estratégia"
                        },
                        new
                        {
                            ID = 6,
                            Name = "RPG"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Multijogador"
                        },
                        new
                        {
                            ID = 8,
                            Name = "3D"
                        },
                        new
                        {
                            ID = 9,
                            Name = "Esporte"
                        },
                        new
                        {
                            ID = 10,
                            Name = "Quebra-Cabeças"
                        },
                        new
                        {
                            ID = 11,
                            Name = "Fantasia"
                        },
                        new
                        {
                            ID = 12,
                            Name = "Corrida"
                        },
                        new
                        {
                            ID = 13,
                            Name = "Anime"
                        },
                        new
                        {
                            ID = 14,
                            Name = "Primeira Pessoa"
                        },
                        new
                        {
                            ID = 15,
                            Name = "Terceira Pessoa"
                        },
                        new
                        {
                            ID = 16,
                            Name = "Ficção Científica"
                        },
                        new
                        {
                            ID = 17,
                            Name = "Arcade"
                        },
                        new
                        {
                            ID = 18,
                            Name = "Terror"
                        },
                        new
                        {
                            ID = 19,
                            Name = "Retro"
                        },
                        new
                        {
                            ID = 20,
                            Name = "Educativo"
                        },
                        new
                        {
                            ID = 21,
                            Name = "Jogo de Tabuleiro"
                        },
                        new
                        {
                            ID = 22,
                            Name = "Co-op"
                        },
                        new
                        {
                            ID = 23,
                            Name = "Mundo Aberto"
                        },
                        new
                        {
                            ID = 24,
                            Name = "Plataformas"
                        },
                        new
                        {
                            ID = 25,
                            Name = "Realidade Virtual"
                        },
                        new
                        {
                            ID = 26,
                            Name = "Sobrevivência"
                        },
                        new
                        {
                            ID = 27,
                            Name = "Ação/Aventura"
                        },
                        new
                        {
                            ID = 28,
                            Name = "Tiro"
                        },
                        new
                        {
                            ID = 29,
                            Name = "Romance Visual"
                        },
                        new
                        {
                            ID = 30,
                            Name = "Point & Click"
                        },
                        new
                        {
                            ID = 31,
                            Name = "Plataforma"
                        },
                        new
                        {
                            ID = 32,
                            Name = "RPG de Ação"
                        },
                        new
                        {
                            ID = 33,
                            Name = "JRPG"
                        });
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Group_Name");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Platform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Platform_Name");

                    b.ToTable("Platform");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ImageUrl = "",
                            Name = "Atari"
                        },
                        new
                        {
                            ID = 2,
                            ImageUrl = "",
                            Name = "Colecovision"
                        },
                        new
                        {
                            ID = 3,
                            ImageUrl = "",
                            Name = "SG-1000"
                        },
                        new
                        {
                            ID = 4,
                            ImageUrl = "",
                            Name = "NES"
                        },
                        new
                        {
                            ID = 5,
                            ImageUrl = "",
                            Name = "Famicom Disk System"
                        },
                        new
                        {
                            ID = 6,
                            ImageUrl = "",
                            Name = "PC Engine"
                        },
                        new
                        {
                            ID = 7,
                            ImageUrl = "",
                            Name = "Master System"
                        },
                        new
                        {
                            ID = 8,
                            ImageUrl = "",
                            Name = "SNES"
                        },
                        new
                        {
                            ID = 9,
                            ImageUrl = "",
                            Name = "Mega Drive"
                        },
                        new
                        {
                            ID = 10,
                            ImageUrl = "",
                            Name = "Sega 32X"
                        },
                        new
                        {
                            ID = 11,
                            ImageUrl = "",
                            Name = "Sega CD"
                        },
                        new
                        {
                            ID = 12,
                            ImageUrl = "",
                            Name = "Game Gear"
                        },
                        new
                        {
                            ID = 13,
                            ImageUrl = "",
                            Name = "Game Boy"
                        },
                        new
                        {
                            ID = 14,
                            ImageUrl = "",
                            Name = "Nintendo 64"
                        },
                        new
                        {
                            ID = 15,
                            ImageUrl = "",
                            Name = "Playstation"
                        },
                        new
                        {
                            ID = 16,
                            ImageUrl = "",
                            Name = "Sega Saturn"
                        },
                        new
                        {
                            ID = 17,
                            ImageUrl = "",
                            Name = "Atari Jaguar"
                        },
                        new
                        {
                            ID = 18,
                            ImageUrl = "",
                            Name = "Game Boy Color"
                        },
                        new
                        {
                            ID = 19,
                            ImageUrl = "",
                            Name = "3DO"
                        },
                        new
                        {
                            ID = 20,
                            ImageUrl = "",
                            Name = "WonderSwan"
                        },
                        new
                        {
                            ID = 21,
                            ImageUrl = "",
                            Name = "WonderSwan Color"
                        },
                        new
                        {
                            ID = 22,
                            ImageUrl = "",
                            Name = "Dreamcast"
                        },
                        new
                        {
                            ID = 23,
                            ImageUrl = "",
                            Name = "Game Boy Advance"
                        },
                        new
                        {
                            ID = 24,
                            ImageUrl = "",
                            Name = "Playstation 2"
                        },
                        new
                        {
                            ID = 25,
                            ImageUrl = "",
                            Name = "Game Cube "
                        },
                        new
                        {
                            ID = 26,
                            ImageUrl = "",
                            Name = "Xbox"
                        },
                        new
                        {
                            ID = 27,
                            ImageUrl = "",
                            Name = "PSP"
                        },
                        new
                        {
                            ID = 28,
                            ImageUrl = "",
                            Name = "Nintendo DS"
                        },
                        new
                        {
                            ID = 29,
                            ImageUrl = "",
                            Name = "Xbox 360"
                        },
                        new
                        {
                            ID = 30,
                            ImageUrl = "",
                            Name = "Wii"
                        },
                        new
                        {
                            ID = 31,
                            ImageUrl = "",
                            Name = "Playstation 3"
                        },
                        new
                        {
                            ID = 32,
                            ImageUrl = "",
                            Name = "Dingoo"
                        },
                        new
                        {
                            ID = 33,
                            ImageUrl = "",
                            Name = "PSVITA"
                        },
                        new
                        {
                            ID = 34,
                            ImageUrl = "",
                            Name = "3DS"
                        },
                        new
                        {
                            ID = 35,
                            ImageUrl = "",
                            Name = "Wii U"
                        },
                        new
                        {
                            ID = 36,
                            ImageUrl = "",
                            Name = "Playstation 4"
                        },
                        new
                        {
                            ID = 37,
                            ImageUrl = "",
                            Name = "Nintendo Switch"
                        },
                        new
                        {
                            ID = 38,
                            ImageUrl = "",
                            Name = "Java - Celular"
                        },
                        new
                        {
                            ID = 39,
                            ImageUrl = "",
                            Name = "Android"
                        });
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Publisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Platform_Name");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ImageUrl = "",
                            Name = "Capcom"
                        });
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Translation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<int?>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("GroupID");

                    b.HasIndex("Language")
                        .HasDatabaseName("IX_Translation_Language");

                    b.ToTable("Translation");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.TranslationImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TranslationID")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("TranslationID");

                    b.ToTable("TranslationImage");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.TranslationVersion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DownloadLink")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PatchNote")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TranslationID")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("ID");

                    b.HasIndex("DownloadLink")
                        .HasDatabaseName("IX_TranslationVersion_DownloadLink");

                    b.HasIndex("TranslationID");

                    b.ToTable("TranslationVersion");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(90)");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.HasIndex("NickName")
                        .HasDatabaseName("IX_User_NickName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TranslationUser", b =>
                {
                    b.Property<int>("TranslationsID")
                        .HasColumnType("int");

                    b.Property<int>("UsersID")
                        .HasColumnType("int");

                    b.HasKey("TranslationsID", "UsersID");

                    b.HasIndex("UsersID");

                    b.ToTable("TranslationUser");
                });

            modelBuilder.Entity("DeveloperGame", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalDeTraducoes.Models.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalDeTraducoes.Models.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalDeTraducoes.Models.Entities.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamePublisher", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalDeTraducoes.Models.Entities.Publisher", null)
                        .WithMany()
                        .HasForeignKey("PublishersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Translation", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Game", "Game")
                        .WithMany("Translations")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PortalDeTraducoes.Models.Entities.Group", "Group")
                        .WithMany("Translations")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Game");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.TranslationImage", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Translation", "Translation")
                        .WithMany("TranslationImages")
                        .HasForeignKey("TranslationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Translation");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.TranslationVersion", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Translation", "Translation")
                        .WithMany("TranslationVersions")
                        .HasForeignKey("TranslationID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Translation");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.User", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Group");
                });

            modelBuilder.Entity("TranslationUser", b =>
                {
                    b.HasOne("PortalDeTraducoes.Models.Entities.Translation", null)
                        .WithMany()
                        .HasForeignKey("TranslationsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalDeTraducoes.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Game", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Group", b =>
                {
                    b.Navigation("Translations");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("PortalDeTraducoes.Models.Entities.Translation", b =>
                {
                    b.Navigation("TranslationImages");

                    b.Navigation("TranslationVersions");
                });
#pragma warning restore 612, 618
        }
    }
}
