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
        }

        public string Author { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
    
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
