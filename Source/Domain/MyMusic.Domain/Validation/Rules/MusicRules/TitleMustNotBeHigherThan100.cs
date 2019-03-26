using MyMusic.Domain.Interfaces.Rule;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Validation.Rules.MusicRules
{
    public class TitleMustBeLowerThan100 : IRule<Music>
    {
        public bool IsSatisfiedBy(Music entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.Title))
                return entity.Title.Length < 100;
            return true;
        }
    }
}
