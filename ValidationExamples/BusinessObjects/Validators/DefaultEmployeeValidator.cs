using BusinessObjects.BaseClasses;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Validators
{
    public class DefaultEmployeeValidator : Validator<Employee>
    {
        public override void ValidateProperty(string propertyName, Employee obj)
        {
            RemoveError(propertyName);
            switch (propertyName)
            {
                case "FirstName":
                    ValidateFirstNameRequired(obj);
                    ValidateFirstNameLength(obj);
                    break;
                case "LastName":
                    ValidateLastNameRequired(obj);
                    ValidateLastNameLength(obj);
                    break;
                case "TerminationDate":
                    ValidateFutureTerminationDate(obj);
                    ValidateTerminationDate(obj);
                    break;
                case "Position":
                    ValidatePosition(obj);
                    break;
                case "Salary":
                    ValidateSalary(obj);
                    break;
                case "HireDate":
                    ValidateHireDateRequired(obj);
                    ValidateHireDate(obj);
                    break;
                default:
                    break;
            }
        }

        #region Salary Validators
        private void ValidateSalary(Employee obj)
        {
            if (obj != null)
            {
                if (obj.Salary < 1)
                {
                    AddError("Salary", ValidationUtilities.GetErrorMessage("SalaryMissing"));
                }
                else
                {
                    if (!IsValidSalaryRange(obj))
                    {
                        AddError("Salary", ValidationUtilities.GetErrorMessage("InvalidSalary"));
                    }
                }
            }

        }
        private bool IsValidSalaryRange(Employee obj)
        {
            switch (obj.Position)
            {
                case Position.Peon:
                    if (obj.Salary < 20800 || obj.Salary > 32000)
                    {
                        return false;
                    }
                    break;
                case Position.NinjaInTraining:
                    if (obj.Salary < 36000 || obj.Salary > 42000)
                    {
                        return false;
                    }

                    break;
                case Position.JourneymanNinja:
                    if (obj.Salary < 44000 || obj.Salary > 56000)
                    {
                        return false;
                    }
                    break;
                case Position.Ninja:
                    if (obj.Salary < 60000 || obj.Salary > 96000)
                    {
                        return false;
                    }
                    break;
                case Position.NinjaMaster:
                    if (obj.Salary < 120000 || obj.Salary > 1000000)
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }
        #endregion

        #region Position Validators
        private void ValidatePosition(Employee obj)
        {
            using (var ctx = new HrContext())
            {
                var AllNames = Enum.GetNames(typeof(Position)).ToList();
                var CurrentName = Enum.GetName(typeof(Position), obj.Position);


                if (obj != null && !AllNames.Contains(CurrentName))
                {
                    AddError("Position", BusinessObjects.ResourceManager.GetString("InvalidPosition"));
                }
            }
        }
        #endregion

        #region Termination Date Validators
        private void ValidateTerminationDate(Employee obj)
        {

            if (obj != null && obj.TerminationDate.HasValue && obj.HireDate.HasValue && obj.TerminationDate.Value < obj.HireDate.Value)
            {
                AddError("TerminationDate", ValidationUtilities.GetErrorMessage("InvalidTerminationDate"));

            }
        }
        private void ValidateFutureTerminationDate(Employee obj)
        {
            if (obj.TerminationDate.HasValue && obj.TerminationDate.Value > DateTime.Now)
            {
                AddError("TerminationDate", ValidationUtilities.GetErrorMessage("InvalidFutureTerminationDate"));
            }
        }
        #endregion
        #region Hire Date Validators
        public void ValidateHireDate(Employee obj)
        {
            if (obj!= null)
            {
                if (obj.HireDate > DateTime.Now)
                {
                    AddError("HireDate", ValidationUtilities.GetErrorMessage("InvalidHireDate"));
                }
            }
        }
        public void ValidateHireDateRequired(Employee obj)
        {
            if (obj != null && !obj.HireDate.HasValue )
            {
                AddError("HireDate", ValidationUtilities.GetErrorMessage("MissingHireDate"));
            }
        }
#endregion 

        #region Last Name Validators
        private void ValidateLastNameRequired(Employee obj)
        {
            if (obj != null)
            {
                if (obj.LastName == null || obj.LastName.Trim().Length < 3)
                {
                    AddError("LastName", ValidationUtilities.GetErrorMessage("MissingLastName"));
                }
            }
        }
        private void ValidateLastNameLength(Employee obj)
        {
            if (obj != null && obj.LastName?.Length > 10)
            {
                AddError("LastName", ValidationUtilities.GetErrorMessage("InvalidLastNameLength"));
            }
        }
        #endregion
        #region First Name Validators
        private void ValidateFirstNameRequired(Employee obj)
        {
            if (obj != null)
            {
                if (obj.FirstName == null || obj.FirstName.Trim().Length < 3)
                {
                    AddError("FirstName", ValidationUtilities.GetErrorMessage("MissingFirstName"));
                }
            }
        }
        private void ValidateFirstNameLength(Employee obj)
        {
            if (obj != null && obj.FirstName?.Length > 10)
            {
                AddError("FirstName", ValidationUtilities.GetErrorMessage("InvalidFirstNameLength"));
            }
        }
        #endregion
    }
}
