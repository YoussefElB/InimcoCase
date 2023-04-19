using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Models;
using Application.CommandHandlers.PersonHandlers;
using Api.Wrapper;
using System.Net;
using Application.QueryHandlers;
using Application.Dtos;

namespace Api.Controllers
{
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }

        #region HttpGet

        /// <summary>
        /// Gets a Person by Id
        /// <response code="200">The found person</response>
        /// <response code="400">One or more validations are not correct</response>
        //[HttpGet("/api/people/{id}")]
        //[ProducesResponseType(typeof(Response<>), 200)]
        //[ProducesResponseType(typeof(Response<>), 400)]
        //public async Task<PersonDto> GetAPerson(int id)
        //{
        //    return await _mediator.Send(new GetPersonQuery(id));
        //}


        /// <summary>
        /// Gets a Person by first name
        /// <response code="200">The found person</response>
        /// <response code="400">One or more validations are not correct</response>
        [HttpGet("/api/people/{name}")]
        [ProducesResponseType(typeof(Response<>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        public async Task<PersonDto> GetAPersonByFirstName(string name)
        {
            //using first name as a search parameter
            return await _mediator.Send(new GetPersonByNameQuery(name));
        }

        #endregion

        #region HttpPost
        /// <summary>
        /// Creates a Person
        /// </summary>
        /// <response code="201">The newly created Person</response>
        /// <response code="400">One or more validations are not correct</response>
        [HttpPost("/api/people")]
        [ProducesResponseType(typeof(Response<>), 201)]
        [ProducesResponseType(typeof(Response<>), 400)]
        public async Task<Person> PostAPerson([FromBody] AddPersonCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion
    }
}
