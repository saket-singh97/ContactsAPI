using System;
using FluentValidation;
namespace ContactsAPI.Models.FluentModelValidation;
       //this is server side validation 
    public class Validator : AbstractValidator<Contacts>
    {
        public Validator()
            {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.").Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.").Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

            RuleFor(x => x.IsFamilyMember).NotNull().WithMessage("IsFamilyMember field is required.");

            RuleFor(x => x.Company).NotEmpty().WithMessage("Company is required.").Length(2, 100).WithMessage("Company name must be between 2 and 100 characters.");

            RuleFor(x => x.JobTitle).NotEmpty().WithMessage("Job title is required.").Length(2, 100).WithMessage("Job title must be between 2 and 100 characters.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.MobilePhone).NotEmpty().WithMessage("Mobile phone is required.").Matches(@"^\d{10}$").WithMessage("Mobile phone must be a 10-digit number.");

            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth is required.").LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.").WithMessage("Age must be at least 18.");

            RuleFor(x => x.AnniversaryDate).GreaterThanOrEqualTo(x => x.DateOfBirth).WithMessage("Anniversary date must be after or the same as the date of birth.");
        }
    }
