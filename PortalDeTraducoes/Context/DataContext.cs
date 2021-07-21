using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalDeTraducoes.Context.Mappings;
using PortalDeTraducoes.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Context
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<TranslationVersion> TranslationVersions { get; set; }   
        
        public DataContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DeveloperMap());
            modelBuilder.ApplyConfiguration(new GameMap());
            modelBuilder.ApplyConfiguration(new GenreMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new PlatformMap());
            modelBuilder.ApplyConfiguration(new PublisherMap());
            modelBuilder.ApplyConfiguration(new TranslationMap());
            modelBuilder.ApplyConfiguration(new TranslationVersionMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());

        }

    }
}
