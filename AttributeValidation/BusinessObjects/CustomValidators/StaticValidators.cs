using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessObjects.CustomValidators
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CheckValidSalaryRange : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Employee emp = value as Employee;
            int minValue = 0;
            int maxValue = 0;
            switch (emp.Position)
            {
                case Position.Peon:
                    minValue = 20800;
                    maxValue = 32000;
                    break;
                case Position.NinjaInTraining:
                    minValue = 36000;
                    maxValue = 42000;
                    break;
                case Position.JourneymanNinja:
                    minValue = 44000;
                    maxValue = 56000;
                    break;
                case Position.Ninja:
                    minValue = 60000;
                    maxValue = 96000;
                    break;
                case Position.NinjaMaster:
                    minValue = 120000;
                    maxValue = 1000000;
                    break;
                default:
                    break;
            }
            if (emp.Salary < minValue || emp.Salary > maxValue)
            {
                return false;
            }
            return true;
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ValidTerminationDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Debug.WriteLine("Termination Date Validator ran");
            var emp = value as Employee;
            if (emp != null)
            {
                if (emp.TerminationDate.HasValue && emp.TerminationDate.Value < emp.HireDate)
                {
                    return false;    
                }
            }
            return true;
        }
    }
}
