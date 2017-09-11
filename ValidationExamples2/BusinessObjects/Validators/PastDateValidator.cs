using FluentValidation.Validators;
using System;

namespace BusinessObjects.Validators
{
    public class PastDateValidator : PropertyValidator
    {
        public PastDateValidator() :base(BusinessObjects.InvalidHireDate)
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var val = context.PropertyValue as DateTime?;

            if (val.HasValue && val.Value < DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
