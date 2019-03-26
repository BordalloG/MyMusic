using MyMusic.Domain.Interfaces.Rule;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Validation.Rules.MusicRules
{
    public class DurationMustNotBeNullOrEmpty : IRule<Music>
    {
        public bool IsSatisfiedBy(Music entity)
        {
            if (entity.Duration != null)
                return TimeSpan.Compare(entity.Duration, new TimeSpan(0, 0, 0)) == 1;
            return false;
        }
    }
}
