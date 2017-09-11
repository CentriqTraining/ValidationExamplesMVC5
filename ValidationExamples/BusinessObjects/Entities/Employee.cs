using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BusinessObjects.BaseClasses;
using BusinessObjects.Factories;

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
    public class Employee : IDataErrorInfo
    {
        private int _ID;
        private readonly DateTime? _CreatedDate;
        private string _FirstName;
        private string _LastName;
        private Position _Position;
        private decimal _Salary;
        private DateTime? _HireDate;
        private DateTime? _TerminationDate;
        private Validator<Employee> _Val;

        public Employee()
        {
            _Val = EmployeeValidatorFactory.GetValidator();
            _CreatedDate = DateTime.Now;
        }

        public string this[string columnName] => _Val[columnName];

        public string Error => string.Empty;

        public int ID
        {
            get => _ID;
            set
            {
                _ID = value;
                _Val.ValidateProperty(nameof(ID), this);
            }
        }

        public string FirstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;
                _Val.ValidateProperty(nameof(FirstName), this);
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
                _Val.ValidateProperty(nameof(LastName), this);
            }
        }

        public Position Position
        {
            get => _Position;
            set
            {
                _Position = value;
                _Val.ValidateProperty(nameof(Position), this);
            }
        }

        public decimal Salary
        {
            get => _Salary;
            set
            {
                _Salary = value;
                _Val.ValidateProperty(nameof(Salary), this);
            }
        }

        public DateTime? TerminationDate
        {
            get => _TerminationDate;
            set
            {
                _TerminationDate = value;
                _Val.ValidateProperty(nameof(TerminationDate), this);
            }
        }

        public DateTime? CreatedDate { get => _CreatedDate; }
        public DateTime? HireDate
        {
            get => _HireDate;
            set
            {
                _HireDate = value;
                _Val.ValidateProperty(nameof(HireDate), this);
            }
        }
    }
}
