using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsLibrary.API.Entities
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        public ICollection<ContactSkill> ContactSkills { get; set; }
            = new List<ContactSkill>();
    }
}
