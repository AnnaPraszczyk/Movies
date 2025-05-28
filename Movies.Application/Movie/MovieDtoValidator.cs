using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Movie
{
    public class MovieDtoValidator : AbstractValidator<MovieDto>
    {
        public MovieDtoValidator() 
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Title should have at least 2 characters")
                .MaximumLength(50).WithMessage("Title should have maximum 50 characters");

            RuleFor(c => c.Description)
               .NotEmpty().WithMessage("Insert description");

            RuleFor(c => c.Year)
            .NotEmpty().WithMessage("Year is required.")
            .Matches(@"^\d{4}$").WithMessage("Year must be in the format yyyy.")
            .Must(y => int.TryParse(y, out int year) && year >= 1900 && year <= DateTime.Now.Year)
            .WithMessage("Year must be a valid four-digit year.");
        }
    }
}
