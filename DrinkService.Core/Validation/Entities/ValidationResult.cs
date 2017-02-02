using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkService.Core.Validation.Entities
{
    public class ValidationResult
    {
        private readonly bool _isValid;
        private readonly List<string> _errorList;

        public ValidationResult(bool isValid, List<string> errorList)
        {
            _isValid = isValid;
            _errorList = errorList;
        }

        public bool IsValid { get { return _isValid; } }
        public List<string> ErrorList { get { return _errorList; } }
    }
}
