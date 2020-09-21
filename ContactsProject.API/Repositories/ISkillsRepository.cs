using ContactsLibrary.API.Entities;
using System;
using System.Collections.Generic;

namespace ContactsLibrary.API.Repositories
{
    /// <summary>
    /// The skills repository offers access to skills data
    /// </summary>
    public interface ISkillsRepository
    {
        /// <summary>
        /// Gets all skills
        /// </summary>
        IEnumerable<Skill> GetSkills();

        /// <summary>
        /// Gets a certain skill by its identifier
        /// </summary>
        /// <param name="skillId">The skill identifier</param>
        Skill GetSkill(Guid skillId);

        /// <summary>
        /// Gets the skills by contact identifier
        /// </summary>
        /// <param name="contactId">The contact identifier</param>
        IEnumerable<Skill> GetSkillsByContact(Guid contactId);

        /// <summary>
        /// Adds a skill
        /// </summary>
        /// <param name="skill">The skill to be added</param>
        void AddSkill(Skill skill);

        /// <summary>
        /// Updates a skill
        /// </summary>
        /// <param name="skill">The skill to update properties</param>
        void UpdateSkill(Skill skill);

        /// <summary>
        /// Deletes a skill
        /// </summary>
        /// <param name="skill"></param>
        void DeleteSkill(Skill skill);

        /// <summary>
        /// Checks if skill exists
        /// </summary>
        /// <param name="skillId"></param>
        bool SkillExists(Guid skillId);

        /// <summary>
        /// Save to database
        /// </summary>
        /// <returns>Returns "true" is succeded</returns>
        bool Save();
    }
}
