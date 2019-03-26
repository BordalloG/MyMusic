using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMusic.Domain.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors;
        private string Message { get; set; }
        public bool IsValid { get { return !_errors.Any(); } }
        public IEnumerable<ValidationError> Errors{ get { return _errors;  } }

        public ValidationResult()
        {
            _errors = new List<ValidationError>();
        }


        public ValidationResult Add(string errorMessege)
        {
            _errors.Add(new ValidationError(errorMessege));
            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            _errors.Add(error);
            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                _errors.AddRange(result.Errors);

            return this;
        }

        public ValidationResult Remove(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
            return this;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            _errors.ForEach(x => sb.Append(x.Message+" "));
            return sb.ToString(); 
        }
    }
}
