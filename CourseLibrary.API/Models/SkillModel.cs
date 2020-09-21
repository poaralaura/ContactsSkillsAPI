using ContactsProject.API.Helpers;
using System;

namespace ContactsLibrary.API.Models
{
    /// <summary>
    /// The view model of the skill returned by the API
    /// </summary>
    public class SkillModel
    {
        /// <summary>
        /// The skill identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The skill name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The skill level
        /// </summary>
        public SkillLevel Level { get; set; }
    }
}
