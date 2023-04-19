using FluentValidation;
using System.Text.RegularExpressions;

namespace Models
{
    public class SocialAccount
        //Nice class huh? You could definetly validate this class with FluentValidation. So that's what we're gonna do.
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }

    public class SocialAccountValidator : AbstractValidator<SocialAccount>
    {
        public SocialAccountValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is empty chief")
                .MaximumLength(50).WithMessage("Social platform gotta be less than or equal to 50 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Yes, an empty url. Nice.")
                .MaximumLength(100).WithMessage("No way an adress is this long buddy")
                .Matches(@"^(?:http|https)://", RegexOptions.IgnoreCase)
                .WithMessage("How is your URL not starting with'http://' or 'https://'. ???");
        }
    }
}
