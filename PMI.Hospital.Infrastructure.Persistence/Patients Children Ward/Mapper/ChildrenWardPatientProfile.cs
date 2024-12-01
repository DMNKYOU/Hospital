using AutoMapper;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.Models;

namespace PMI.Hospital.Infrastructure.Persistence.People.Mapper
{
    /// <summary>
    /// An AutoMapper profile for patient models.
    /// </summary>
    public sealed class ChildrenWardPatientProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleProfile"/> class.
        /// </summary>
        public ChildrenWardPatientProfile()
        {
            CreateMap<ChildrenWardPatientEntity, ChildrenWardPatientDto>()
                .ForMember(p => p.Id, o => o.MapFrom(x => x.Id))
                .ForMember(p => p.Active, o => o.MapFrom(x => x.Active))
                .ForMember(p => p.Person, o => o.MapFrom(x => x.Person))
                .ReverseMap();
        }
    }
}
