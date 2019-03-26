using MyMusic.Domain.Interfaces.Rule;
using System;
using System.Collections.Generic;
using System.Text;
using MyMusic.Domain.Models;

namespace MyMusic.Domain.Validation.Rules.MusicRules
{
    public class AuthorMustNotBeNullOrEmpty : IRule<Music>
    {
        public bool IsSatisfiedBy(Music entity)
        {
            return ! String.IsNullOrWhiteSpace(entity.Author);
        }
    }
}
