using BusinessObjects.BaseClasses;
using BusinessObjects.Entities;
using BusinessObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Factories
{
    public static class EmployeeValidatorFactory
    {
        public static Validator<Employee> GetValidator()
        {
            return new DefaultEmployeeValidator();
        }
    }

}
