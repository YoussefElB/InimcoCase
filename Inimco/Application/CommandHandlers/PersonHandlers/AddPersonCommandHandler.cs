using Application.Dtos;
using MediatR;
using Models;
using Repository.Repository;

namespace Application.CommandHandlers.PersonHandlers
{
    public class AddPersonCommand : IRequest<Person>
    {
        public AddPersonDto Person { get; set; }
        public IList<AddSocialAccountDto> SocialAccounts { get; }

        public AddPersonCommand(AddPersonDto person, IList<AddSocialAccountDto> socialAccounts)
        {
            Person = person;
            SocialAccounts = socialAccounts;
        }
    }

    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Person>
    {
        private readonly IRepository<Person> _repo;
        private readonly IMediator _mediator;
        public AddPersonCommandHandler(IRepository<Person> repo, IMediator mediator)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(IRepository<Person>));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Person> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                FirstName = request.Person.FirstName,
                LastName = request.Person.LastName,
                SocialSkills = request.Person.SocialSkills,
                SocialAccounts = new List<SocialAccount>()
            };

            foreach (var socialAccountDto in request.SocialAccounts)
            {
                var socialAccount = new SocialAccount
                {
                    Type = socialAccountDto.Type,
                    Address = socialAccountDto.Adress,
                    Person = person
                };

                person.SocialAccounts.Add(socialAccount);
            }

            _repo.Add(person);
            await _repo.SaveChangesAsync();

            return person;
        }
    }
}
