using AutoMapper;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.Models;

namespace PMI.Hospital.Infrastructure.Persistence.People.Mapper
{
    /// <summary>
    /// An AutoMapper profile for peron models.
    /// </summary>
    public sealed class PeopleProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleProfile"/> class.
        /// </summary>
        public PeopleProfile()
        {
            CreateMap<PersonEntity, PersonDto>()
                .ForMember(p => p.Id, o => o.MapFrom(x => x.Id))
                .ForMember(p => p.Family, o => o.MapFrom(x => x.Family))
                .ForMember(p => p.FirstName, o => o.MapFrom(x => x.FirstName))
                .ForMember(p => p.MiddleName, o => o.MapFrom(x => x.MiddleName))
                .ForMember(p => p.Use, o => o.MapFrom(x => x.Use))
                .ForMember(p => p.Gender, o => o.MapFrom(x => x.Gender))
                .ForMember(p => p.BirthDate, o => o.MapFrom(x => x.BirthDate))
                .ReverseMap();

            CreateMap<PersonEntity, PersonExtendedDto>()
               .IncludeBase <PersonEntity, PersonDto>()
               .ForMember(p => p.PatientActiveState, o =>
                {
                    o.PreCondition(x => x.ChildrenWardPatient != null);
                    o.MapFrom(x => x.ChildrenWardPatient.Active);
                });
        }
    }
}
