using BusinessObjects.Entities;
using BusinessObjects.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Factories
{
    public static class EmployeeValidatorFactory
    {
        public static AbstractValidator<Employee> GetValidator()
        {
            return new DefaultEmployeeValidator();
        }
    }

}
