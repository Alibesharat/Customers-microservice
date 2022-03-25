using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Validators.Extensssion
{
    public static class UtilExtession
    {

        public static List<string> GetErrors(this ValidationResult result)
        {
            return result.Errors.Select(c => c.ErrorMessage).ToList();
        }
    }
}
