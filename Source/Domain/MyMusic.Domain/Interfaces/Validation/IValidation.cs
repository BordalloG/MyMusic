using MyMusic.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
