using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.CustomValidators
{
    public class NotJustSpaces : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string val = (string)value;

            return val.Trim().Length > 0;
        }
    }
}
