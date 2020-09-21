using System;

namespace ContactsLibrary.API.Models
{
    /// <summary>
    /// The view model of the contact returned by the API
    /// </summary>
    public class ContactModel
    {
        /// <summary>
        /// The contact identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The contact name
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// The contact address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The contact email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The contact mobile number
        /// </summary>
        public string Mobile { get; set; }

    }
}
