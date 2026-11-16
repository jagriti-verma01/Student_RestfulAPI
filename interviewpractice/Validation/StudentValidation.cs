using FluentValidation;
using interviewpractice.Models;

namespace interviewpractice.Validation
{
    public class StudentValidation : AbstractValidator<StudentModel>
    {
        public StudentValidation()
        {
            RuleFor(x => x.id)
                .GreaterThan(0)
                .WithMessage("StudentId must be greater than 0.");

            RuleFor(x => x.name)
                .NotEmpty()
                .WithMessage("Student name is required.")
                .MaximumLength(50)
                .WithMessage("Student name cannot exceed 50 characters.");
        }
    }
}
