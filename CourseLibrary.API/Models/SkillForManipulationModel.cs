using ContactsProject.API.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsLibrary.API.Models
{
    /// <summary>
    /// The manipulation view model of the skill used by the API
    /// </summary>
    public class SkillForManipulationModel
    {
        /// <summary>
        /// The skill name
        /// </summary>
        [Required(ErrorMessage = "You should fill out a name.")]
        [MaxLength(50, ErrorMessage = "The name shouldn't have more than 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// The skill level
        /// </summary>
        [Required(ErrorMessage = "You should fill out a level.")]
        public SkillLevel Level { get; set; }

        public ICollection<ContactForManipulationModel> Contacts { get; set; }
             = new List<ContactForManipulationModel>();
    }
}
