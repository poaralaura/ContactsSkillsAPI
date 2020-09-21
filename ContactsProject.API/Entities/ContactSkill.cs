using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsLibrary.API.Entities
{
    public class ContactSkill
    {
        [Key]
        public Guid ContactId { get; set; }

        public Contact Contact { get; set; }

        [Key]
        public Guid SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}
