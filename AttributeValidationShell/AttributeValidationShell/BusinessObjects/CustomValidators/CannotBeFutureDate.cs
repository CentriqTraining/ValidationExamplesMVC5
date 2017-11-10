using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.CustomValidators
{
    public class CannotBeFutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var val = value as DateTime?;
            return val.HasValue && val.Value <= DateTime.Now;
        }
    }
}
