using Application.Dtos;
using Application.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Repository;

namespace Application.QueryHandlers
{
    public class GetPersonByNameQuery : IRequest<PersonDto>
    {
        public string Name { get; set; }

        public GetPersonByNameQuery(string name)
        {
            Name = name;
        }
    }
    internal class GetPersonByNameQueryHandler : IRequestHandler<GetPersonByNameQuery, PersonDto>
    {
        private readonly IRepository<Person> _repository;
        private readonly IMediator _mediator;

        public GetPersonByNameQueryHandler(IRepository<Person> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<PersonDto> Handle(GetPersonByNameQuery request, CancellationToken cancellationToken)
        {
            //using first name as the search parameter
            var person = await _repository.Query(p => p.FirstName == request.Name).Result
                                           .Include(p => p.SocialAccounts)
                                           .FirstOrDefaultAsync();

            return PersonMapper.MapToDto(person);
        }
    }
}
