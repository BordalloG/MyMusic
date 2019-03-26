using MyMusic.Domain.Interfaces.Rule;
using MyMusic.Domain.Interfaces.Validation;
using System;
using System.Collections.Generic;


namespace MyMusic.Domain.Validation
{
    public class Validation<TEntity> : IValidation<TEntity>
        where TEntity : class
    {

        private readonly Dictionary<string, IValidationRule<TEntity>> _validationRules;

        public Validation()
        {
            _validationRules = new Dictionary<string, IValidationRule<TEntity>>();
        }

        protected virtual void AddRule(IValidationRule<TEntity> validationRule)
        {
            var ruleName = validationRule.GetType() + Guid.NewGuid().ToString("D");
            _validationRules.Add(ruleName, validationRule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            _validationRules.Remove(ruleName);
        }

        public virtual ValidationResult Valid(TEntity entity)
        {
            var result = new ValidationResult();
            foreach (var key in _validationRules.Keys)
            {
                var rule = _validationRules[key];
                if (!rule.Valid(entity))
                    result.Add(new ValidationError(rule.ErrorMessage));
            }
            return result;
        }

    }
}
