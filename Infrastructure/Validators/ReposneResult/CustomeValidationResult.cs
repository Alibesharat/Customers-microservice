using System.Collections.Generic;

namespace Validators
{
    public class CustomeValidationResult
    {
        public bool IsValid { get; set; }

        public List<string> Errors { get; set; }
    }
}
