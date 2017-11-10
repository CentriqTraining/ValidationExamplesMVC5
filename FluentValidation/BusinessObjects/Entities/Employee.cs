using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BusinessObjects.Factories;
using FluentValidation;
using FluentValidation.Attributes;
using BusinessObjects.Validators;

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
    [Validator(typeof(DefaultEmployeeValidator))]
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
            set => _ID = value;
        }

        public string FirstName
        {
            get => _FirstName;
            set => _FirstName = value;
        }

        public string LastName
        {
            get => _LastName;
            set => _LastName = value;
        }

        public Position Position
        {
            get => _Position;
            set => _Position = value;
        }

        public decimal Salary
        {
            get => _Salary;
            set => _Salary = value;
        }

        public DateTime? TerminationDate
        {
            get => _TerminationDate;
            set => _TerminationDate = value;
        }

        public DateTime? CreatedDate { get => _CreatedDate; }
        public DateTime? HireDate
        {
            get => _HireDate;
            set => _HireDate = value;
        }
    }
}
