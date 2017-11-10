using BusinessObjects.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Validators
{
    public class DefaultEmployeeValidator : AbstractValidator<Employee>
    {
        public DefaultEmployeeValidator()
        {
            RuleFor(e => e.FirstName)
                .NotNull()
                .WithMessage(BusinessObjects.MissingFirstName);
            RuleFor(e => e.FirstName)
                .MaximumLength(10)
                .WithMessage(BusinessObjects.InvalidLastNameLength);
            RuleFor(e => e.FirstName)
                .Must(f => f?.Trim() != string.Empty)
                .WithMessage(BusinessObjects.MissingFirstName);

            RuleFor(e => e.LastName)
                .NotNull()
                .WithMessage(BusinessObjects.MissingLastName);
            RuleFor(e => e.LastName)
                .MaximumLength(10)
                .WithMessage(BusinessObjects.InvalidLastNameLength);
            RuleFor(e => e.LastName)
                .Must(f => f?.Trim() != string.Empty)
                .WithMessage(BusinessObjects.MissingLastName);

            RuleFor(e => e.HireDate)
                .NotNull()
                .WithMessage(BusinessObjects.MissingHireDate);
            RuleFor(e => e.HireDate)
                .SetValidator(new PastDateValidator())
                .WithMessage(BusinessObjects.InvalidHireDate);

            RuleFor(e => e.Position)
                .IsInEnum()
                .WithMessage(BusinessObjects.InvalidPosition);

            RuleFor(e => e.Salary)
                .NotEqual(0)
                .WithMessage(BusinessObjects.SalaryMissing);
            //Peon: 20800 - 32000
            When(e => e.Position == Position.Peon,
                () => 
                {
                    RuleFor(e => e.Salary)
                        .LessThanOrEqualTo(32000)
                        .GreaterThanOrEqualTo(20800)
                        .WithMessage(BusinessObjects.InvalidSalary);
                });
            //Ninja In Training: 36000 - 42000
            When(e => e.Position == Position.NinjaInTraining,
                () => 
                {
                    RuleFor(e => e.Salary)
                        .LessThanOrEqualTo(42000)
                        .GreaterThanOrEqualTo(36000)
                        .WithMessage(BusinessObjects.InvalidSalary);
                });
            //Journeyman Ninja: 44000 - 56000
            When(e => e.Position == Position.JourneymanNinja,
                () =>
                {
                    RuleFor(e => e.Salary)
                        .LessThanOrEqualTo(56000)
                        .GreaterThanOrEqualTo(44000)
                        .WithMessage(BusinessObjects.InvalidSalary);
                });
            //Ninja: 60000 - 96000
            When(e => e.Position == Position.Ninja,
                () =>
                {
                    RuleFor(e => e.Salary)
                        .LessThanOrEqualTo(96000)
                        .GreaterThanOrEqualTo(60000)
                        .WithMessage(BusinessObjects.InvalidSalary);
                });
            //Ninja Master: 120000 - 1000000
            When(e => e.Position == Position.NinjaMaster,
                () =>
                {
                    RuleFor(e => e.Salary)
                        .LessThanOrEqualTo(1000000)
                        .GreaterThanOrEqualTo(120000)
                        .WithMessage(BusinessObjects.InvalidSalary);
                });

            When(e => e.TerminationDate.HasValue,
                () =>
                RuleFor(e => e.TerminationDate)
                    .LessThanOrEqualTo(DateTime.Now)
                    .GreaterThan(e => e.HireDate)
                    .WithMessage(BusinessObjects.InvalidFutureTerminationDate)
                );
        }
    }
}
