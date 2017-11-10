using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BusinessObjects.CustomValidators;

namespace BusinessObjects.Entities
{
    public enum Position
    {
        Peon,
        NinjaInTraining,
        JourneymanNinja,
        Ninja,
        NinjaMaster
    }
    [ValidTerminationDate(ErrorMessageResourceName = "InvalidTerminationDate",
                    ErrorMessageResourceType =typeof(ValidationErrorMessages))]
    [CheckValidSalaryRange(ErrorMessageResourceName = "InvalidSalary",
                ErrorMessageResourceType = typeof(ValidationErrorMessages))]
    public class Employee
    {
        private int _ID;
        private readonly DateTime? _CreatedDate;
        private string _FirstName;
        private string _LastName;
        private Position _Position;
        private decimal _Salary;
        private DateTime? _HireDate;
        private DateTime? _TerminationDate;

        public Employee()
        {
            _CreatedDate = DateTime.Now;
        }

        public int ID
        {
            get => _ID;
            set
            {
                _ID = value;
            }
        }

        [Required(ErrorMessageResourceName = "MissingFirstName",
                ErrorMessageResourceType =typeof(ValidationErrorMessages))]
        [StringLength(10, 
                ErrorMessageResourceName = "InvalidFirstNameLength",
                ErrorMessageResourceType = typeof(ValidationErrorMessages))]
        public string FirstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;
            }
        }

        [Required(ErrorMessageResourceName = "MissingLastName",
                    ErrorMessageResourceType =typeof(ValidationErrorMessages))]
        [StringLength(10,
            ErrorMessageResourceName = "InvalidLastNameLength",
            ErrorMessageResourceType = typeof(ValidationErrorMessages))]
        public string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
            }
        }

        [Range(0, 4, ErrorMessageResourceName ="InvalidPosition",
                    ErrorMessageResourceType = typeof(ValidationErrorMessages))]
        public Position Position
        {
            get => _Position;
            set
            {
                _Position = value;
            }
        }

        [Range(1,1000000, ErrorMessageResourceName = "SalaryMissing",
                    ErrorMessageResourceType =typeof(ValidationErrorMessages))]
        public decimal Salary
        {
            get => _Salary;
            set => _Salary = value;
        }

        [CannotBeFutureDate(ErrorMessageResourceName ="InvalidFutureTerminationDate",
                             ErrorMessageResourceType =typeof(ValidationErrorMessages))]
        public DateTime? TerminationDate
        {
            get => _TerminationDate;
            set
            {
                _TerminationDate = value;
            }
        }

        public DateTime? CreatedDate { get => _CreatedDate; }
        [Required(ErrorMessageResourceName ="MissingHireDate",
                    ErrorMessageResourceType = typeof(ValidationErrorMessages))]
        [CannotBeFutureDate]
        public DateTime? HireDate
        {
            get => _HireDate;
            set
            {
                _HireDate = value;
            }
        }
    }
}
