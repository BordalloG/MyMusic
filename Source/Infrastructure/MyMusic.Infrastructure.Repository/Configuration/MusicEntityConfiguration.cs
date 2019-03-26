using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Domain.Models;
using MyMusic.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Infrastructure.Repository.Configuration
{
    public class MusicEntityConfiguration : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.Ignore(x => x.Duration);
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(y => y.IsValid);
            builder.ToTable(nameof(Music));
        }
    }
}
