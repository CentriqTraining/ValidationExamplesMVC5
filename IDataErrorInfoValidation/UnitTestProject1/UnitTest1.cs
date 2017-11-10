using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
using BusinessObjects.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Employee x;
        private HrContext ctx;

        [TestInitialize]
        public void TestInit()
        {
            x = new Employee();
             ctx = new HrContext();
        }

        [TestMethod] public void FirstNameMissingTest()
        {
            x.FirstName = "  ";

            var expected = ValidationUtilities.GetErrorMessage("MissingFirstName");
            var actual = x["FirstName"];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod] public void FirstNameLengthTest()
        {
            //  Arrange
            x.FirstName = new string('X', 11);
            var expected = ValidationUtilities.GetErrorMessage("InvalidFirstNameLength");

            //  Act
            var actual = x["FirstName"];

            //  Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void LastNameMissingTest()
        {
            x.LastName = null;

            var expected = ValidationUtilities.GetErrorMessage("MissingLastName");
            var actual = x["LastName"];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod] public void LastNameLengthTest()
        {
            x.LastName = new string('X', 11);

            var expected = ValidationUtilities.GetErrorMessage("InvalidLastNameLength");

            var actual = x["LastName"];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void TerminationFutureDateTest()
        {
            //  Termination date cannot be in the future
            //  Respond with error message "Termination date cannot be in the future"
            x.TerminationDate = DateTime.Now.AddDays(5);

            var expected = ValidationUtilities.GetErrorMessage("InvalidFutureTerminationDate");
            var actual = x["TerminationDate"];


            Assert.AreEqual(expected, actual);
        }
        [TestMethod] public void TerminationDateTest()
        {
            //  Termination date cannot be before Hire Date
            //  Respond with the error message "Termination date cannot be before Hire Date"
            x.HireDate = DateTime.Now;
            x.TerminationDate = DateTime.Now.AddMinutes(-2);

            var expected = ValidationUtilities.GetErrorMessage("InvalidTerminationDate");
            var actual = x["TerminationDate"];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void CreatedDateTest()
        {
            var now = DateTime.Now;

            Assert.IsTrue(x.CreatedDate <= now);
        }

        [TestMethod] public void HireDateMissingTest()
        {
            x.HireDate = null;

            var expected = ValidationUtilities.GetErrorMessage("MissingHireDate");
            var actual = x["HireDate"];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void SalaryMissingTest()
        {
            x.Salary = 0;

            var expected = ValidationUtilities.GetErrorMessage("SalaryMissing");
            var actual = x["Salary"];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod] public void SalaryOutOfRangeTest()
        {
            x.Position = Position.JourneymanNinja;
            x.Salary = 100000;

            var expected = ValidationUtilities.GetErrorMessage("InvalidSalary");
            var actual = x["Salary"];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void PositionInvalidTest()
        {
            x.Position = (Position)50;
            var expected = ValidationUtilities.GetErrorMessage("InvalidPosition");
            var actual = x["Position"];

            Assert.AreEqual(expected, actual);

        }
    }
}
