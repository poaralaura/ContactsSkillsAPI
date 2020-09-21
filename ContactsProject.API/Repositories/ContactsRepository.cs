using ContactsLibrary.API.DbContexts;
using ContactsLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsLibrary.API.Repositories
{
    /// <summary>
    /// The contacts repository offers access to contact data
    /// </summary>
    public class ContactsRepository : IContactsRepository, IDisposable
    {
        private readonly ContactLibraryContext _context;

        public ContactsRepository(ContactLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets all contacts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.ToList<Contact>();
        }

        /// <summary>
        /// Get contact by its identifier
        /// </summary>
        /// <param name="contactId">The contact identifier</param>
        public Contact GetContact(Guid contactId)
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            return _context.Contacts.FirstOrDefault(a => a.Id == contactId);
        }

        /// <summary>
        /// Get contacts by skill identifier
        /// </summary>
        /// <param name="skillId">The skill identfier</param>
        public IEnumerable<Contact> GetContactsBySkill(Guid skillId)
        {
            if (skillId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(skillId));
            }

            return _context.Contacts
                .Where(c => c.ContactSkills.Where(s => s.SkillId == skillId).Any())
                .OrderBy(c => c.LastName)
                .ToList();
        }

        /// <summary>
        /// Checks if contact exists
        /// </summary>
        /// <param name="contactId">The contact identifier</param>
        public bool ContactExists(Guid contactId)
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            return _context.Contacts.Any(a => a.Id == contactId);
        }

        /// <summary>
        /// Adds a contact to the data store
        /// </summary>
        /// <param name="contact">The contact to be added</param>
        public void AddContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            // the repository fills the id (instead of using identity columns)
            contact.Id = Guid.NewGuid();

            foreach (var skill in contact.ContactSkills)
            {
                if(!SkillExists(skill.SkillId))
                    skill.SkillId = Guid.NewGuid();
            }

            _context.Contacts.Add(contact);
        }

        /// <summary>
        /// Updates contact data
        /// </summary>
        /// <param name="contact">The contact to be updated</param>
        public void UpdateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            _context.Contacts.Update(contact);
        }

        /// <summary>
        /// Deletes a contact
        /// </summary>
        /// <param name="contact"></param>
        public void DeleteContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            _context.Contacts.Remove(contact);
        }

        /// <summary>
        /// Final sane to the data store
        /// </summary>
        /// <returns>Returns true if succeded</returns>
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        private bool SkillExists(Guid skillId)
        {
            if (skillId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(skillId));
            }

            return _context.Skills.Any(a => a.Id == skillId);
        }
    }
}
