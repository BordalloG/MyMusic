using MyMusic.Domain.Interfaces.Rule;

namespace MyMusic.Domain.Validation
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        private readonly IRule<TEntity> _rule;
        public string ErrorMessage { get; private set; }

        public ValidationRule( IRule<TEntity> rule, string errorMessage )
        {
            _rule = rule;
            ErrorMessage = errorMessage;
        }
        public bool Valid(TEntity entity)
        {
            return _rule.IsSatisfiedBy(entity);
        }

    }
}
