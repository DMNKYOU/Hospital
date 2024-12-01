using AutoMapper;
using PMI.Hospital.Contracts.ChildrenWardPatients.Responses;
using PMI.Hospital.Contracts.People;
using PMI.Hospital.Core.Models.People;

namespace PMI.Hospital.Infrastructure.Mapper
{
    /// <summary>
    /// An AutoMapper profile for patient models.
    /// </summary>
    public sealed class ChildrenWardPatientModelProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrenWardPatientModelProfile"/> class.
        /// </summary>
        public ChildrenWardPatientModelProfile()
        {
            //CreateMap<PersonCreateRequest, CreatePersonCommand>()
            //    .ForMember(p => p.Family, o => o.MapFrom(x => x.Family))
            //    .ForMember(p => p.FirstName, o => o.MapFrom(x => x.FirstName))
            //    .ForMember(p => p.MiddleName, o => o.MapFrom(x => x.MiddleName))
            //    .ForMember(p => p.Use, o => o.MapFrom(x => x.Use))
            //    .ForMember(p => p.Gender, o => o.MapFrom(x => x.Gender))
            //    .ForMember(p => p.BirthDate, o => o.MapFrom(x => x.BirthDate));

            CreateMap<ChildrenWardPatientDto, ChildrenPatientResponse>()
               .ForMember(p => p.Name, o =>
               {
                   o.PreCondition(x => x.Person != null);
                   o.MapFrom(x => x.Person);
               })
                .ForMember(p => p.Gender, o =>
                {
                    o.PreCondition(x => x.Person != null);
                    o.MapFrom(x => x.Person.Gender);
                })
                .ForMember(p => p.BirthDate, o =>
                {
                    o.PreCondition(x => x.Person != null);
                    o.MapFrom(x => x.Person.BirthDate);
                });


            CreateMap<PersonDto, PatientDataResponse>()
                .ForMember(p => p.Id, o => o.MapFrom(x => x.Id))
                .ForMember(p => p.Use, o => o.MapFrom(x => x.Use))
                .ForMember(p => p.Family, o => o.MapFrom(x => x.Family))
                .ForMember(p => p.Given, o => o.MapFrom(x => CreateGiven(x.FirstName, x.MiddleName)));
        }

        private List<string> CreateGiven(string firstName, string middleName)
        {
            var given = new[] { firstName, middleName }
                .Where(name => !string.IsNullOrEmpty(name))
                .ToList();

            return given.Any() ? given : null;
        }
    }
}
