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
            //  Talk to the Validator factory and inject 
            //  the appropriate validator
            _Val = EmployeeValidatorFactory.GetValidator();
            _CreatedDate = DateTime.Now;
        }

        //  As the Model binder assembles the appropriate paramters
        //  It will do a test to see if the model class implements various
        //  interfaces (in our case IDataErrorInfo).  It will then
        //  automatically call this indexer for each and every property
        //  assignment and add each error the the error collection.
        public string this[string columnName] => _Val[columnName];

        public string Error => string.Empty;

        public int ID
        {
            get => _ID;
            set
            {
                //  When each property changes, make a call to the 
                //  Validator class telling it to validate this property
                _ID = value;
                _Val.ValidateProperty(nameof(ID), this);
            }
        }

        public string FirstName
        {
            get => _FirstName;
            set
            {
                //  When each property changes, make a call to the 
                //  Validator class telling it to validate this property
                _FirstName = value;
                _Val.ValidateProperty(nameof(FirstName), this);
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                //  When each property changes, make a call to the 
                //  Validator class telling it to validate this property
                _LastName = value;
                _Val.ValidateProperty(nameof(LastName), this);
            }
        }

        public Position Position
        {
            get => _Position;
            set
            {
                //  When each property changes, make a call to the 
                //  Validator class telling it to validate this property
                _Position = value;
                _Val.ValidateProperty(nameof(Position), this);
            }
        }

        public decimal Salary
        {
            get => _Salary;
            set
            {
                //  When each property changes, make a call to the 
                //  Validator class telling it to validate this property
                _Salary = value;
                _Val.ValidateProperty(nameof(Salary), this);
            }
        }

        public DateTime? TerminationDate
        {
            get => _TerminationDate;
            set
            {
                //  When each property changes, make a call to the 
                //  Validator class telling it to validate this property
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
                //  When each property changes, make a call to the 
                //  Validator class telling it to validate this property
                _HireDate = value;
                _Val.ValidateProperty(nameof(HireDate), this);
            }
        }
    }
}
