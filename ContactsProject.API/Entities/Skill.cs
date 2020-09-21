using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsLibrary.API.Entities
{
	public class Skill
    {
        [Key]       
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public byte Level { get; set; }

        public ICollection<ContactSkill> ContactSkills { get; set; }
            = new List<ContactSkill>();
    }
}
