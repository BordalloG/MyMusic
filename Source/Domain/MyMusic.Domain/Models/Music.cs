using MyMusic.Domain.Models.Validations;
using MyMusic.Domain.Validation;
using System;

namespace MyMusic.Domain.Models
{
    public class Music : Entity
    {
        public Music(string author, string title, TimeSpan duration)
        {
            Author = author;
            Title = title;
            Duration = duration;
            DurationTicks = duration.Ticks;
        }

        public Music(string author, string title, long durationTicks)
        {
            Author = author;
            Title = title;
            Duration = TimeSpan.FromTicks(durationTicks);
            DurationTicks = durationTicks;
        }

        public string Author { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public long DurationTicks { get; set; }

        public ValidationResult ValidationResult { get; private set; }
        public bool IsValid
        {
            get
            {
                var fiscal = new MusicIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
        
    }
}
