using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Business.ChildrenWardPatients.Services;
using PMI.Hospital.Business.People.Services;
using PMI.Hospital.Contracts.ChildrenWardPatients;
using PMI.Hospital.Contracts.ChildrenWardPatients.Responses;
using PMI.Hospital.Contracts.People;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;

namespace PMI.Hospital.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/patients")]
    [ApiController]
    public class ChildrenWardPatientsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IChildrenWardPatientService childrenWardPatientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="childrenWardPatientService">The child patients service.</param>
        public ChildrenWardPatientsController(
            IMapper mapper,
            IChildrenWardPatientService childrenWardPatientService)
        {
            this.mapper = mapper;
            this.childrenWardPatientService = childrenWardPatientService;
        }

        /// <summary>
        /// Gets a patient collection based on date.
        /// </summary>
        // This could be part of the GET ALL ITEMS API, with an additional query parameter for search functionality.
        [HttpPost("searchByDate")] 
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<ChildrenPatientResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ICollection<ChildrenPatientResponse>> SearchByDate([FromBody] PatientSearchRequest request)
        {
            var result = await childrenWardPatientService.ListEntitiesByDate(request.SearchTerm);

            return this.mapper.Map<ICollection<ChildrenPatientResponse>>(result);
        }

        /// <summary>
        /// Gets a patient.
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ChildrenPatientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ChildrenPatientResponse> Get([FromRoute] string id)
        {
            var result = await childrenWardPatientService.Get(id);

            return this.mapper.Map<ChildrenPatientResponse>(result);
        }

        /// <summary>
        /// Creates a patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Created entity.</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task Create([FromBody] ChildrenPatientCreateRequest request)
        {
            await childrenWardPatientService.Create(
                request.PersonId,
                request.Active);

            this.Response.StatusCode = StatusCodes.Status201Created;
        }

        /// <summary>
        /// Updates a person.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Created entity.</returns>
        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ChildrenPatientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ChildrenPatientResponse> UpdateState([FromBody] ChildrenPatientUpdateRequest request)
        {
            var result = await childrenWardPatientService.ChangeActiveState(request.Id, request.Active);

            return this.mapper.Map<ChildrenPatientResponse>(result);
        }

        /// <summary>
        /// Removes a patient info.
        /// </summary>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task Remove([FromRoute] string id)
        {
            await childrenWardPatientService.Remove(id);
        }
    }
}
