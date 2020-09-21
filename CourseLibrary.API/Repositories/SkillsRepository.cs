using ContactsLibrary.API.DbContexts;
using ContactsLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsLibrary.API.Repositories
{
    /// <summary>
    /// The skills repository offers access to skills data
    /// </summary>
    public class SkillsRepository : ISkillsRepository, IDisposable
    {
        private readonly ContactLibraryContext _context;

        public SkillsRepository(ContactLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets all skills
        /// </summary>
        public IEnumerable<Skill> GetSkills()
        {
            return _context.Skills.ToList<Skill>();
        }

        /// <summary>
        /// Gets a certain skill by its identifier
        /// </summary>
        /// <param name="skillId">The skill identifier</param>
        public Skill GetSkill(Guid skillId)
        {
            if (skillId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(skillId));
            }

            return _context.Skills.FirstOrDefault(a => a.Id == skillId);
        }

        /// <summary>
        /// Gets the skills by contact identifier
        /// </summary>
        /// <param name="contactId">The contact identifier</param>
        public IEnumerable<Skill> GetSkillsByContact(Guid contactId)
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            return _context.Skills
                .Where(s => s.ContactSkills.Where(c => c.ContactId == contactId).Any())
                .OrderBy(s => s.Name)
                .ToList();
        }

        /// <summary>
        /// Adds a skill
        /// </summary>
        /// <param name="skill">The skill to be added</param>
        public bool SkillExists(Guid skillId)
        {
            if (skillId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(skillId));
            }

            return _context.Skills.Any(a => a.Id == skillId);
        }

        /// <summary>
        /// Adds a skill
        /// </summary>
        /// <param name="skill">The skill to be added</param>
        public void AddSkill(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            // the repository fills the id (instead of using identity columns)
            skill.Id = Guid.NewGuid();

            foreach (var contact in skill.ContactSkills)
            {
                if(!ContactExists(contact.ContactId))
                    contact.ContactId = Guid.NewGuid();
            }

            _context.Skills.Add(skill);
        }

        /// <summary>
        /// Updates a skill
        /// </summary>
        /// <param name="skill">The skill to update properties</param>
        public void UpdateSkill(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            _context.Skills.Update(skill);
        }

        /// <summary>
        /// Deletes a skill
        /// </summary>
        /// <param name="skill"></param>
        public void DeleteSkill(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            _context.Skills.Remove(skill);
        }

        /// <summary>
        /// Final save to database
        /// </summary>
        /// <returns>Returns "true" is succeded</returns>
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

        private bool ContactExists(Guid contactId)
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            return _context.Contacts.Any(a => a.Id == contactId);
        }
    }
}
