using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyMusic.DomainTest.ValidationTest
{
    public class MusicValidationTest
    {
        [Theory]
        [MemberData(nameof(ReturnValidMusic))]
        public void MusicShouldBeValidValidation(string author, string title, TimeSpan duration)
        {
            var music = new Music(author, title, duration);
            Assert.True(music.IsValid);
            Assert.Empty(music.ValidationResult.Errors);
        }

        [Theory]
        [MemberData(nameof(ReturnNotValidMusic))]
        public void MusicShouldNotBeValidValidation(string author, string title, TimeSpan duration)
        {
            var music = new Music(author, title, duration);
            Assert.False(music.IsValid);
            Assert.NotEmpty(music.ValidationResult.Errors);
        }
        public static IEnumerable<object[]> ReturnValidMusic()
        {
            yield return new object[] { "Metallica", "Nothing Else Matters", new TimeSpan(0, 6, 33) };
            yield return new object[] { "Ed Sheeran", "Galway Girl", new TimeSpan(0, 2, 52) };
            yield return new object[] { "Lil Pump", "Butterfly Doors", new TimeSpan(0, 2, 18) };
        }
        public static IEnumerable<object[]> ReturnNotValidMusic()
        {
            yield return new object[] { " ", "Nothing Else Matters", new TimeSpan(0, 6, 33) };
            yield return new object[] { "Ed Sheeran", " ", new TimeSpan(0, 2, 52) };
            yield return new object[] { "Ed Sheeran", null, new TimeSpan(0, 2, 52) };
            yield return new object[] { null, "Butterfly Doors", new TimeSpan(0, 2, 18) };
            yield return new object[] { "Lil Pump", "Butterfly Doors", new TimeSpan(0, 0, 0) };
            yield return new object[] { "Lil Pump", "Butterfly Doors", null };
        }
    }
}
