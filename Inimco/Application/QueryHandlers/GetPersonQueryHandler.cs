using Application.Dtos;
using Application.Mappers;
using MediatR;
using Models;
using Repository.Repository;

namespace Application.QueryHandlers
{
    public class GetPersonQuery : IRequest<PersonDto>
    {
        public int Id { get; set; }

        public GetPersonQuery(int id)
        {
            Id = id;
        }
    }
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonDto>
    {
        private readonly IRepository<Person> _repository;
        private readonly IMediator _mediator;

        public GetPersonQueryHandler(IRepository<Person> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<PersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetAsync(p => p.Id == request.Id);

            if (person == null)
                return null;

            return PersonMapper.MapToDto(person);

        }
    }
}
