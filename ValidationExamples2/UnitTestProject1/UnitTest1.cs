using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects.Entities;
using FluentValidation;
using BusinessObjects.Factories;
using FluentValidation.TestHelper;
using BusinessObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Employee _TestEmployee;
        private AbstractValidator<Employee> _val = EmployeeValidatorFactory.GetValidator();

        [TestInitialize]
        public void TestInit()
        {
            _TestEmployee = new Employee();
        }

        [TestMethod]
        public void FirstNameMissingTest()
        {
            _TestEmployee.FirstName = null;
            _val.ShouldHaveValidationErrorFor(e => e.FirstName, _TestEmployee);

        }
        [TestMethod]
        public void FirstNameLengthTest()
        {
            _TestEmployee.FirstName = new string('X', 11);
            _val.ShouldHaveValidationErrorFor(e => e.FirstName, _TestEmployee);
        }

        [TestMethod]
        public void LastNameMissingTest()
        {
            _TestEmployee.LastName = null;
            _val.ShouldHaveValidationErrorFor(e => e.LastName, _TestEmployee);
        }
        [TestMethod]
        public void LastNameLengthTest()
        {
            _TestEmployee.LastName = new string('X', 11);
            _val.ShouldHaveValidationErrorFor(e => e.LastName, _TestEmployee);
        }

        [TestMethod]
        public void TerminationFutureDateTest()
        {
            _TestEmployee.TerminationDate = DateTime.Now.AddDays(3);
            _val.ShouldHaveValidationErrorFor(e => e.TerminationDate, _TestEmployee);
        }
        [TestMethod]
        public void TerminationDateTest()
        {
            _TestEmployee.HireDate = DateTime.Now.AddDays(-3);
            _TestEmployee.TerminationDate = DateTime.Now.AddDays(-4);
            _val.ShouldHaveValidationErrorFor(e => e.TerminationDate, _TestEmployee);
        }

        [TestMethod]
        public void HireDateTest()
        {
            _TestEmployee.HireDate = DateTime.Now.AddDays(5);
            _val.ShouldHaveValidationErrorFor(e => e.HireDate, _TestEmployee);
        }
        [TestMethod]
        public void HireDateMissingTest()
        {
            _TestEmployee.HireDate = null;
            _val.ShouldHaveValidationErrorFor(e => e.HireDate, _TestEmployee);
        }

        [TestMethod]
        public void SalaryMissingTest()
        {
            _TestEmployee.Salary = 0;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);
        }
        [TestMethod]
        public void SalaryOutOfRangeTest()
        {
                //Peon: 20800 - 32000
            _TestEmployee.Position = Position.Peon;
            _TestEmployee.Salary = 20799;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 33000;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 30000;
            _val.ShouldNotHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            //Ninja In Training: 36000 - 42000
            _TestEmployee.Position = Position.NinjaInTraining;
            _TestEmployee.Salary = 35999;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 37000;
            _val.ShouldNotHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 42001;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            //Journeyman Ninja: 44000 - 56000
            _TestEmployee.Position = Position.JourneymanNinja;
            _TestEmployee.Salary = 43999;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 46000;
            _val.ShouldNotHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 56001;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            //Ninja: 60000 - 96000
            _TestEmployee.Position = Position.Ninja;
            _TestEmployee.Salary = 59999;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 65000;
            _val.ShouldNotHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 96001;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            //Ninja Master: 120000 - 1000000
            _TestEmployee.Position = Position.NinjaMaster;
            _TestEmployee.Salary = 119999;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 200000;
            _val.ShouldNotHaveValidationErrorFor(e => e.Salary, _TestEmployee);

            _TestEmployee.Salary = 1000001;
            _val.ShouldHaveValidationErrorFor(e => e.Salary, _TestEmployee);

        }

        [TestMethod]
        public void PositionInvalidTest()
        {
            _TestEmployee.Position = (Position)50;
            _val.ShouldHaveValidationErrorFor(e => e.Position, _TestEmployee);
        }

        [TestMethod]
        public void CreatedDateTest()
        {
            var expected = DateTime.Now;
            var actual = _TestEmployee.CreatedDate;

            Assert.IsTrue(actual <= expected);
        }
    }
}
