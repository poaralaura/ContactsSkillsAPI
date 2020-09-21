using ContactsProject.API.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsLibrary.API.Models
{
    /// <summary>
    /// The manipulation view model of the contact used by the API
    /// </summary>
    public class ContactForManipulationModel
    {
        /// <summary>
        /// The contact first name
        /// </summary>
        [Required(ErrorMessage = "You should fill out a first name.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// The contact last name
        /// </summary>
        [Required(ErrorMessage = "You should fill out a last name.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// The contact address
        /// </summary>
        [Required(ErrorMessage = "You should fill out an address.")]
        [MaxLength(100, ErrorMessage = "The adress shouldn't have more than 100 characters.")]
        [RegularExpression(SharedRegex.OpenTextRegex, ErrorMessage ="The address doens't have the correct format.")]
        public string Address { get; set; }

        /// <summary>
        /// The contact email
        /// </summary>
        [Required(ErrorMessage = "You should fill out an email.")]
        [RegularExpression(SharedRegex.Email, ErrorMessage = "The email format is not correct.")]
        public string Email { get; set; }

        /// <summary>
        /// The contact mobile number
        /// </summary>
        [Required(ErrorMessage = "You should fill out a mobile number.")]
        [RegularExpression(SharedRegex.OpenTextRegex, ErrorMessage ="The mobile number is not correct.")]
        public string Mobile { get; set; }

        public ICollection<SkillForManipulationModel> Skills { get; set; }
            = new List<SkillForManipulationModel>();

    }
}
