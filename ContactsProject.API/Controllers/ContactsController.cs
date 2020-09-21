using AutoMapper;
using ContactsLibrary.API.Models;
using ContactsLibrary.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactsLibrary.API.Controllers
{
	/// <summary>
	/// The CRUD operations for contacts
	/// </summary>
	[ApiController]
	[Route("api/contacts")]
	public class ContactsController : ControllerBase
	{
		private readonly IContactsRepository _contactsRepository;
		private readonly ISkillsRepository _skillsRepository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Creates an instance of <see cref="ContactsController"/>
		/// </summary>
		/// <param name="contactsRepository">The contacts repository acces</param>
		/// <param name="skillsRepository">The skills repository access</param>
		/// <param name="mapper">Automapper used to map the repository model to the view model</param>
		public ContactsController(IContactsRepository contactsRepository, ISkillsRepository skillsRepository, IMapper mapper)
		{
			_contactsRepository = contactsRepository ??
				throw new ArgumentNullException(nameof(contactsRepository));
			_skillsRepository = skillsRepository ??
				throw new ArgumentNullException(nameof(skillsRepository));
			_mapper = mapper ??
				throw new ArgumentNullException(nameof(mapper));
		}

		/// <summary>
		/// Retrieve all the contacts
		/// </summary>
		/// <returns></returns>
		[HttpGet(Name = "GetContacts")]
		public ActionResult<IEnumerable<ContactModel>> GetContacts()
		{
			var contactsFromRepo = _contactsRepository.GetContacts();
			return Ok(_mapper.Map<IEnumerable<ContactModel>>(contactsFromRepo));
		}

		/// <summary>
		/// Retrieve the contacts by contact id
		/// </summary>
		/// <param name="contactId">The contact identifier</param>
		[HttpGet("{contactId}", Name = "GetContact")]
		public IActionResult GetContact(Guid contactId)
		{
			var contactFromRepo = _contactsRepository.GetContact(contactId);

			if (contactFromRepo == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ContactModel>(contactFromRepo));
		}

		/// <summary>
		/// Retrieve contacts for a skill
		/// </summary>
		/// <param name="skillId">The skill identifier</param>
		[HttpGet("skill/{skillId}", Name = "GetContactsForSkill")]
		public ActionResult<IEnumerable<ContactModel>> GetContactsForSkill(Guid skillId)
		{
			if (!_skillsRepository.SkillExists(skillId))
			{
				return NotFound();
			}

			var contactsForSkillFromRepo = _contactsRepository.GetContactsBySkill(skillId);
			return Ok(_mapper.Map<IEnumerable<ContactModel>>(contactsForSkillFromRepo));
		}

		/// <summary>
		/// Create a contact
		/// </summary>
		/// <param name="contact">The contact details to be saved</param>
		/// <returns>The contact saved</returns>
		[HttpPost]
		public ActionResult<ContactModel> CreateContact(ContactForManipulationModel contact)
		{
			var contactEntity = _mapper.Map<Entities.Contact>(contact);
			_contactsRepository.AddContact(contactEntity);
			_contactsRepository.Save();

			var contactToReturn = _mapper.Map<ContactModel>(contactEntity);
			return CreatedAtRoute("GetContact",
				new { contactId = contactToReturn.Id },
				contactToReturn);
		}

		/// <summary>
		/// Update the contact data for the specified contact id
		/// </summary>
		/// <param name="contactId">The contact identifier</param>
		/// <param name="contact">The contact details to be updated</param>
		[HttpPut("{contactId}")]
		public IActionResult UpdateContact(Guid contactId, ContactForManipulationModel contact)
		{
			var contactFromRepo = _contactsRepository.GetContact(contactId);

			if (contactFromRepo == null)
			{
				var contactToAdd = _mapper.Map<Entities.Contact>(contact);
				contactToAdd.Id = contactId;

				_contactsRepository.AddContact(contactToAdd);

				_contactsRepository.Save();

				var contactToReturn = _mapper.Map<ContactModel>(contactToAdd);

				return CreatedAtRoute("GetContact",
					new { contactId = contactToReturn.Id },
					contactToReturn);
			}

			// map the entity to a ContactForUpdateModel
			// apply the updated field values to that dto
			// map the ContactForUpdateModel back to an entity
			_mapper.Map(contact, contactFromRepo);

			_contactsRepository.UpdateContact(contactFromRepo);

			_contactsRepository.Save();
			return NoContent();
		}

		/// <summary>
		/// Delete a contact based on the contact id
		/// </summary>
		/// <param name="contactId">The contact identifier</param>
		[HttpDelete("{contactId}")]
		public ActionResult DeleteContact(Guid contactId)
		{
			if (!_contactsRepository.ContactExists(contactId))
			{
				return NotFound();
			}

			var contactFromRepo = _contactsRepository.GetContact(contactId);

			if (contactFromRepo == null)
			{
				return NotFound();
			}

			_contactsRepository.DeleteContact(contactFromRepo);
			_contactsRepository.Save();

			return NoContent();
		}
	}
}
