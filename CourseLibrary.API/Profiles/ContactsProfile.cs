using AutoMapper;

namespace ContactsLibrary.API.Profiles
{
    /// <summary>
    /// The contact profile used to map repository entities to the view model ones
    /// </summary>
	public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<Entities.Contact, Models.ContactModel>()
                .ForMember(
                    dest => dest.Name, 
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Models.ContactForManipulationModel, Entities.Contact>();
        }
    }
}
