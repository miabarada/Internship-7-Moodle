using Domain.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model
{
    public class ValidationResultItem
    {
        public ValidationSeverity ValidationSeverity { get; init; }
        public ValidationType ValidationType { get; init; }
        public string? Code { get; set; }
        public string? Message { get; set; }

        public static ValidationResultItem FromValidationItem(ValidationItem validationItem)
        {
            return new ValidationResultItem
            {
                ValidationSeverity = validationItem.ValidationSeverity,
                ValidationType = validationItem.ValidationType,
                Code = validationItem.Code,
                Message = validationItem.Message
            };
        }
    }
}
