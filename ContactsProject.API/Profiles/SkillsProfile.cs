using AutoMapper;
using ContactsLibrary.API.Entities;
using ContactsLibrary.API.Models;
using ContactsLibrary.API.Helpers;

namespace ContactsLibrary.API.Profiles
{
	/// <summary>
	/// The skill profile used to map repository entities to the view model ones
	/// </summary>
	public class SkillsProfile : Profile
	{
		public SkillsProfile()
		{
			CreateMap<Skill, SkillModel>()
				.ForMember(
					dest => dest.Level,
					opt => opt.MapFrom(src => (SkillLevel)src.Level));

			CreateMap<SkillModel, Skill>()
				.ForMember(
					dest => dest.Level,
					opt => opt.MapFrom(src => (byte)src.Level));

			CreateMap<SkillForManipulationModel, Skill>().ForMember(
				dest => dest.Level,
				opt => opt.MapFrom(src => (byte)src.Level));

			CreateMap<Skill, SkillForManipulationModel>().ForMember(
				dest => dest.Level,
				opt => opt.MapFrom(src => (SkillLevel)src.Level));
		}
	}
}
