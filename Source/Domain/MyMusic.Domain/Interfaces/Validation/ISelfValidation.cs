using MyMusic.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; } 
    }

}
