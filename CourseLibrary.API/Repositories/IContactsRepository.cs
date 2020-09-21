using ContactsLibrary.API.Entities;
using System;
using System.Collections.Generic;

namespace ContactsLibrary.API.Repositories
{
	/// <summary>
	/// The contacts repository offers access to contact data
	/// </summary>
	public interface IContactsRepository
	{
		/// <summary>
		/// Gets all contacts
		/// </summary>
		/// <returns></returns>
		IEnumerable<Contact> GetContacts();

		/// <summary>
		/// Get contact by its identifier
		/// </summary>
		/// <param name="contactId">The contact identifier</param>
		Contact GetContact(Guid contactId);

		/// <summary>
		/// Get contacts by skill identifier
		/// </summary>
		/// <param name="skillId">The skill identfier</param>
		IEnumerable<Contact> GetContactsBySkill(Guid skillId);

		/// <summary>
		/// Adds a contact to the data store
		/// </summary>
		/// <param name="contact">The contact to be added</param>
		void AddContact(Contact contact);

		/// <summary>
		/// Deletes a contact
		/// </summary>
		/// <param name="contact"></param>
		void DeleteContact(Contact contact);

		/// <summary>
		/// Updates contact data
		/// </summary>
		/// <param name="contact">The contact to be updated</param>
		void UpdateContact(Contact contact);

		/// <summary>
		/// Checks if contact exists
		/// </summary>
		/// <param name="contactId">The contact identifier</param>
		bool ContactExists(Guid contactId);

		/// <summary>
		/// Final sane to the data store
		/// </summary>
		/// <returns>Returns true if succeded</returns>
		bool Save();
	}
}
