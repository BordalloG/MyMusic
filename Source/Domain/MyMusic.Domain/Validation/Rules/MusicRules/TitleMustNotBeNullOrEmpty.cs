using MyMusic.Domain.Interfaces.Rule;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Validation.Rules.MusicRules
{
    public class TitleMustNotBeNullOrEmpty : IRule<Music>
    {
        public bool IsSatisfiedBy(Music entity)
        {
            return ! String.IsNullOrWhiteSpace(entity.Title);
        }
    }
}
