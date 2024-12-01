using AutoMapper;
using PMI.Hospital.Contracts.People;
using PMI.Hospital.Core.Models.People;

namespace PMI.Hospital.Infrastructure.Mapper
{
    /// <summary>
    /// An AutoMapper profile for peron models.
    /// </summary>
    public sealed class PeopleModelProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleModelProfile"/> class.
        /// </summary>
        public PeopleModelProfile()
        {
            CreateMap<PersonCreateRequest, CreatePersonCommand>()
                .ForMember(p => p.Family, o => o.MapFrom(x => x.Family))
                .ForMember(p => p.FirstName, o => o.MapFrom(x => x.FirstName))
                .ForMember(p => p.MiddleName, o => o.MapFrom(x => x.MiddleName))
                .ForMember(p => p.Use, o => o.MapFrom(x => x.Use))
                .ForMember(p => p.Gender, o => o.MapFrom(x => x.Gender))
                .ForMember(p => p.BirthDate, o => o.MapFrom(x => x.BirthDate));
        }
    }
}
