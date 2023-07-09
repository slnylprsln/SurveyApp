using FluentValidation;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class CreateNewUserRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public Role Role { get; set; }
    }

    public class UserCreateValidator : AbstractValidator<CreateNewUserRequest>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Please enter a valid email address!");
            RuleFor(x => x.UserName)
                .MaximumLength(50).WithMessage("Username cannot be longer than 50 characters!")
                .MinimumLength(3).WithMessage("Username cannot be shorter than 3 characters!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty!")
                .MinimumLength(9).WithMessage("Password length must be at least 8.")
                .MaximumLength(50).WithMessage("Password length must be at most 50.")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                .Matches(@"[\!\*\.\$]+").WithMessage("Password must contain at least one (!*.).");
        }
    }
}
