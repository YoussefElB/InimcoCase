using Application.CommandHandlers.PersonHandlers;
using Application.Dtos;
using Application.QueryHandlers;
using MediatR;
using Models;
using Repository.Repository;

namespace Api
{
    public static class IoCHelper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //see mediatr 12.0 for migration
            services.AddScoped(typeof(IRepository<Person>), typeof(Repository<Person>));
            services.AddScoped(typeof(IRepository<SocialAccount>), typeof(Repository<SocialAccount>));

            services.AddScoped<IRequestHandler<AddPersonCommand, Person>, AddPersonCommandHandler>();
            services.AddScoped<IRequestHandler<GetPersonQuery, PersonDto>, GetPersonQueryHandler>();

            services.AddScoped<IRepository<Person>, Repository<Person>>();
        }
    }
}
