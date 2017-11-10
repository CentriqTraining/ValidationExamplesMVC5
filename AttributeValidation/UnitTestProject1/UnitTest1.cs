using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
using BusinessObjects.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects.CustomValidators;
using System.Web.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Employee x;
        private ValidationContext Validationctx;
        private List<ValidationResult> results;
        [TestInitialize]
        public void TestInit()
        {
            x = new Employee();
            Validationctx = new ValidationContext(x);
            results = new List<ValidationResult>();
        }

        [TestMethod]
        public void FirstNameMissingTest()
        {
            //  Arrange
            string expected = ValidationErrorMessages.MissingFirstName;

            // Act
            x.FirstName = "  ";
            Validator.TryValidateObject(x, Validationctx, results);

            //  Assert
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }
        [TestMethod]
        public void FirstNameLengthTest()
        {
            //  Arrange
            string expected = ValidationErrorMessages.InvalidFirstNameLength;

            //  Act
            x.FirstName = new string('X', 12);
            Validator.TryValidateObject(x, Validationctx, results, true);

            //  Assert
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }

        [TestMethod]
        public void LastNameMissingTest()
        {
            string expected = ValidationErrorMessages.MissingLastName;

            x.LastName = null;
            Validator.TryValidateObject(x, Validationctx, results, true);

            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }
        [TestMethod]
        public void LastNameLengthTest()
        {
            //  Arrange
            string expected = ValidationErrorMessages.InvalidLastNameLength;

            //  Act
            x.LastName = new string('X', 11);
            Validator.TryValidateObject(x, Validationctx, results, true);

            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }

        [TestMethod]
        public void TerminationFutureDateTest()
        {
            //  Arrange
            string expected = ValidationErrorMessages.InvalidFutureTerminationDate;

            //  Act
            x.TerminationDate = DateTime.Now.AddDays(5);
            Validator.TryValidateObject(x, Validationctx, results, true);

            //  Assert
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }
        [TestMethod]
        public void TerminationDateTest()
        {
            //  Arrange
            var expected = ValidationErrorMessages.InvalidTerminationDate;

            //  Act
            //  Icky work-around here
            //  Validator will do property level validation first
            //  Because the Class level validation is more expensive
            //    if it encounters ANY errors on property level 
            //    validation attributes
            //  the class level validation is completely skipped.
            
            //////////////////////////////////////
            // Remove these lines of code       //
            // and the whole thing doesn't work //
            // ADD another validator...same     //
            //////////////////////////////////////
            x.FirstName = "Mike";
            x.LastName = "Rissen";
            x.Salary = 30000;
            /////////////////////////////////////

            //  The actual pertinent properties to validate
            x.HireDate = DateTime.Now;
            x.TerminationDate = DateTime.Now.AddDays(-2);
            Validator.TryValidateObject(x, Validationctx, results, true);

            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }

        [TestMethod]
        public void CreatedDateTest()
        {
            DateTime now = DateTime.Now;

            Assert.IsTrue(x.CreatedDate <= now);
        }

        [TestMethod]
        public void HireDateMissingTest()
        {
            //  Arrange
            var expected = ValidationErrorMessages.MissingHireDate;
            //  Act
            x.HireDate = null;
            Validator.TryValidateObject(x, Validationctx, results, true);

            //  Assert
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }

        [TestMethod]
        public void SalaryMissingTest()
        {
            //  Arrange
            var expected = ValidationErrorMessages.SalaryMissing;

            //  Act
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }
        [TestMethod]
        public void SalaryOutOfRangeTest()
        {
            var expected = ValidationErrorMessages.InvalidSalary;
            x.FirstName = "Mike";
            x.LastName = "Rissen";
            x.Position = Position.Peon;
            x.Salary = 20799;
            x.HireDate = DateTime.Now.AddDays(-1);
            x.TerminationDate = DateTime.Now;

            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
            x.Salary = 32001;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));

            x.Position = Position.NinjaInTraining;
            x.Salary = 35999;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
            x.Salary = 42001;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));

            x.Position = Position.JourneymanNinja;
            x.Salary = 43999;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
            x.Salary = 56001;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));

            x.Position = Position.Ninja;
            x.Salary = 59999;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
            x.Salary = 96001;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));

            x.Position = Position.NinjaMaster;
            x.Salary = 119999;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
            x.Salary = 1000001;
            Validator.TryValidateObject(x, Validationctx, results, true);
            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }

        [TestMethod]
        public void PositionInvalidTest()
        {
            //  Arrange
            var expected = ValidationErrorMessages.InvalidPosition;

            //  Act
            x.Position = (Position)50;
            Validator.TryValidateObject(x, Validationctx, results, true);

            Assert.IsTrue(results.Any(e => e.ErrorMessage == expected));
        }
    }
}
