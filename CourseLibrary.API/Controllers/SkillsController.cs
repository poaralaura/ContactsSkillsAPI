using AutoMapper;
using ContactsLibrary.API.Models;
using ContactsLibrary.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactsLibrary.API.Controllers
{
    /// <summary>
    /// The CRUD operations for skills
    /// </summary>
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ISkillsRepository _skillsRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates an instance of <see cref="SkillsController"/>
        /// </summary>
        /// <param name="contactsRepository">The contacts repository acces</param>
        /// <param name="skillsRepository">The skills repository access</param>
        /// <param name="mapper">Automapper used to map the repository model to the view model</param>
        public SkillsController(IContactsRepository contactsRepository, ISkillsRepository skillsRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository ??
                throw new ArgumentNullException(nameof(contactsRepository));
            _skillsRepository = skillsRepository ??
                throw new ArgumentNullException(nameof(skillsRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Retrieve all the skills
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<IEnumerable<SkillModel>> GetSkills()
        {
            var skillsFromRepo = _skillsRepository.GetSkills();
            return Ok(_mapper.Map<IEnumerable<SkillModel>>(skillsFromRepo));
        }

        /// <summary>
        /// Retrieve the skills by skill id
        /// </summary>
        /// <param name="skillId">The skill identifier</param>
        /// <returns></returns>
        [HttpGet("{skillId}", Name = "GetSkill")]
        public IActionResult GetSkill(Guid skillId)
        {
            var skillFromRepo = _skillsRepository.GetSkill(skillId);

            if (skillFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SkillModel>(skillFromRepo));
        }

        /// <summary>
        /// Retrieve skills for a contact
        /// </summary>
        /// <param name="contactId">The contact identifier</param>
        [HttpGet("contact/{contactId}", Name = "GetSkillsForContact")]
        public ActionResult<IEnumerable<SkillModel>> GetSkillsForContact(Guid contactId)
        {
            if (!_contactsRepository.ContactExists(contactId))
            {
                return NotFound();
            }

            var skillsForContactFromRepo = _skillsRepository.GetSkillsByContact(contactId);
            return Ok(_mapper.Map<IEnumerable<SkillModel>>(skillsForContactFromRepo));
        }

        /// <summary>
        /// Create a skill
        /// </summary>
        /// <param name="skill">The skill details to be saved</param>
        /// <returns>The skill saved</returns>
        [HttpPost]
        public ActionResult<SkillModel> CreateSkill(SkillForManipulationModel skill)
        {
            var skillEntity = _mapper.Map<Entities.Skill>(skill);
            _skillsRepository.AddSkill(skillEntity);
            _skillsRepository.Save();

            var skillToReturn = _mapper.Map<SkillModel>(skillEntity);
            return CreatedAtRoute("GetSkill",
                new { skillId = skillToReturn.Id },
                skillToReturn);
        }

        /// <summary>
        /// Update the skill data for the specified skill id
        /// </summary>
        /// <param name="skillId">The skill identifier</param>
        /// <param name="skill">The skill details to be updated</param>
        [HttpPut("{skillId}")]
        public IActionResult UpdateSkill(Guid skillId, SkillForManipulationModel skill)
        {
            var skillFromRepo = _skillsRepository.GetSkill(skillId);

            if (skillFromRepo == null)
            {
                var skillToAdd = _mapper.Map<Entities.Skill>(skill);
                skillToAdd.Id = skillId;

                _skillsRepository.AddSkill(skillToAdd);

                _skillsRepository.Save();

                var skillToReturn = _mapper.Map<SkillModel>(skillToAdd);

                return CreatedAtRoute("GetSkill",
                    new { skillId = skillToReturn.Id },
                    skillToReturn);
            }

            // map the entity to a SkillForManipulationModel
            // apply the updated field values to that dto
            // map the SkillForManipulationModel back to an entity
            _mapper.Map(skill, skillFromRepo);

            _skillsRepository.UpdateSkill(skillFromRepo);

            _skillsRepository.Save();
            return NoContent();
        }

        /// <summary>
        /// Delete a skill based on the skill id
        /// </summary>
        /// <param name="skillId">The skill identifier</param>
        [HttpDelete("{skillId}")]
        public ActionResult DeleteSkill(Guid skillId)
        {
            if (!_skillsRepository.SkillExists(skillId))
            {
                return NotFound();
            }

            var skillFromRepo = _skillsRepository.GetSkill(skillId);

            if (skillFromRepo == null)
            {
                return NotFound();
            }

            _skillsRepository.DeleteSkill(skillFromRepo);
            _skillsRepository.Save();

            return NoContent();
        }
    }
}