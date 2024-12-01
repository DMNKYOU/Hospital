using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Business.People.Services;
using PMI.Hospital.Contracts.People;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;

namespace PMI.Hospital.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPersonService personService;
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="personService">The people service.</param>
        public PeopleController(
            IMapper mapper,
            IPersonService personService)
        {
            this.mapper = mapper;
            this.personService = personService;
        }

        /// <summary>
        /// Gets a person.
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<PersonResponse> Get([FromRoute] string personId)
        {
            var result = await personService.Get(personId);

            return this.mapper.Map<PersonResponse>(result);
        }

        /// <summary>
        /// Create a person.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Created entity.</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<PersonResponse> Create([FromBody] PersonCreateRequest request)
        {
            var result = await personService.Create(this.mapper.Map<CreatePersonCommand>(request));

            return this.mapper.Map<PersonResponse>(result);
        }

        /// <summary>
        /// Removes a person.
        /// </summary>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task Remove([FromRoute] string personId)
        {
            await personService.Remove(personId); 
        }
    }
}
