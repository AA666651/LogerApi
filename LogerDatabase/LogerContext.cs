using System;
using System.Collections.Generic;
using LogerCommon;
using LogerDatabase.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace LogerDatabase
{
    public class LogerContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        
        public LogerContext()
        {
        }

        public LogerContext(DbContextOptions<LogerContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=127.0.0.01;database=X;User ID=sa;password=X;trusted_connection=false;Persist Security Info=False;Encrypt=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRelations(modelBuilder);
            ConfigureIndex(modelBuilder);
            ConfigureSeed(modelBuilder);
        }

        protected void ConfigureIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogType>()
                .HasKey(x => x.Id)
                .IsClustered();
            modelBuilder.Entity<Log>()
                .HasKey(x => x.Id)
                .IsClustered();
        }
        protected void ConfigureRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogType>()
                .HasMany(c => c.Logs)
                .WithOne(e => e.LogType);
            
            modelBuilder.Entity<Log>()
                .HasOne(e => e.LogType)
                .WithMany(c => c.Logs);
        }
        protected void ConfigureSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogType>().HasData(
                new LogType() {Id = 1, Name = LogerType.INFO.ToString() },
                new LogType() {Id = 2, Name = LogerType.WARNING.ToString() },
                new LogType() {Id = 3, Name = LogerType.ERROR.ToString() }

            );
        }
    }
   

    
}