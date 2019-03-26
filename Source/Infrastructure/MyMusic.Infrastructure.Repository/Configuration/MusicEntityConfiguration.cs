using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Infrastructure.Repository.Configuration
{
    public class MusicEntityConfiguration : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable(nameof(Music));
        }
    }
}
