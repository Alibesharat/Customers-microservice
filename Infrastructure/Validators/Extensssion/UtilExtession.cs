using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Extensssion
{
    public static class UtilExtession
    {

        public static string ErrorsToString(this ValidationResult result)
        {
            return string.Join(',', result.Errors.Select(c => c.ErrorMessage));
        }
    }
}
