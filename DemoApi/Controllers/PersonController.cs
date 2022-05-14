using DemoCQRS;
using DemoCQRS.Commands;
using DemoCQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    /// <summary>
    /// Intro to MediatR - Implementing CQRS and Mediator Patterns
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IMediator _mediatoR;

        public PersonController(IMediator mediator)
        {
            _mediatoR = mediator;
        }

        [HttpGet]
        public async Task<List<PersonModel>> Get()
        {
            return await _mediatoR.Send(new GetPersonListQuery());
        }


        [HttpGet("{id}")]
        public async Task<PersonModel> Get(int id)
        {
            return await _mediatoR.Send(new GetPersonByIdQuery(id));
        }

        [HttpPost]
        public async Task<PersonModel> Post(PersonModel value)
        {
            return await _mediatoR.Send(new InsertPersonCommand(value.FirstName,value.LastName));
        }

    }
}
