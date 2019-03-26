using Microsoft.EntityFrameworkCore;
using MyMusic.Domain.Models;
using MyMusic.Infrastructure.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Infrastructure.Repository.Context
{
    public class MyMusicContext : DbContext
    {
        DbSet<Music> Music { get; set; }
        private readonly string _connectionString;

        public MyMusicContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new MusicEntityConfiguration());
        }
    }
}
