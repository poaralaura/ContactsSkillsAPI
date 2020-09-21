using ContactsLibrary.API.Entities;
using ContactsProject.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsLibrary.API.DbContexts
{
    public class ContactLibraryContext : DbContext
    {
        public ContactLibraryContext(DbContextOptions<ContactLibraryContext> options)
           : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ContactSkill> ContactsSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Contact>().HasData(
                new Contact()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Berry",
                    LastName = "Griffin",
                    Email = "bery.griffin@gmail.com",
                    Address = "First Street No 12 Milano Italy",
                    Mobile = "0745616789"
                },
                new Contact()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Nancy",
                    LastName = "Rye",
                    Email = "nancy.rye@gmail.com",
                    Address = "Second Street No 1 Milano Italy",
                    Mobile = "0745616789"
                },
                new Contact()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    FirstName = "Eli",
                    LastName = "Bones",
                    Email = "eli.bones@gmail.com",
                    Address = "Third Street No 12 Rome Italy",
                    Mobile = "0745616789"
                },
                new Contact()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    FirstName = "Arnold",
                    LastName = "Stanford",
                    Email = "arnold.stanford@gmail.com",
                    Address = "Third Street No 15 Rome Italy",
                    Mobile = "0745616789"
                },
                new Contact()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    FirstName = "Linda",
                    LastName = "Well",
                    Email = "linda.well@gmail.com",
                    Address = "Third Street No 15 Barcelona Spain",
                    Mobile = "0745616789"
                },
                new Contact()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    FirstName = "Ruthe",
                    LastName = "Cloven",
                    Email = "ruthe.cloven@gmail.com",
                    Address = "Third Street No 16 Barcelona Spain",
                    Mobile = "0745616789"
                },
                new Contact()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    FirstName = "Amy",
                    LastName = "Ridley",
                    Email = "amy.ridley@ygmail.com",
                    Address = "Fall Street No 72 Switzerland",
                    Mobile = "0745616789"
                },
                new Contact()
                {
                    Id = Guid.Parse("71838f8b-6ab3-4539-9e67-4e77b8ede1c0"),
                    FirstName = "Morris",
                    LastName = "Lessmore",
                    Email = "morris.lessmore@gmail.com",
                    Address = "Fall Street No 72 Switzerland",
                    Mobile = "0745616789"
                }
                );

            modelBuilder.Entity<Skill>().HasData(
               new Skill
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   Level = (byte)SkillLevel.Beginner,
                   Name = "Beginner"
               },
               new Skill
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   Level = (byte)SkillLevel.Intermediate,
                   Name = "Intermediate"
               },
               new Skill
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   Level = (byte)SkillLevel.Advanced,
                   Name = "Advanced"
               });

            modelBuilder.Entity<ContactSkill>().HasData(
               new ContactSkill
               {
                   ContactId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   SkillId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
               },
               new ContactSkill
               {
                   ContactId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   SkillId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee")
               },
               new ContactSkill
               {
                   ContactId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   SkillId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
               },
               new ContactSkill
               {
                   ContactId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   SkillId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
               },
               new ContactSkill
               {
                   ContactId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   SkillId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
               },
               new ContactSkill
               {
                   ContactId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                   SkillId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
               },
                new ContactSkill
                {
                    ContactId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    SkillId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
                },
                new ContactSkill
                {
                    ContactId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    SkillId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee")
                },
                new ContactSkill
                {
                    ContactId = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    SkillId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee")
                },
                new ContactSkill
                {
                    ContactId = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    SkillId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
                },
                new ContactSkill
                {
                    ContactId = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    SkillId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee")
                },
                new ContactSkill
                {
                    ContactId = Guid.Parse("71838f8b-6ab3-4539-9e67-4e77b8ede1c0"),
                    SkillId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee")
                }
               );

            modelBuilder.Entity<ContactSkill>()
                .HasKey(bc => new { bc.ContactId, bc.SkillId });

            modelBuilder.Entity<ContactSkill>()
                .HasOne(cs => cs.Contact)
                .WithMany(c => c.ContactSkills)
                .HasForeignKey(cs => cs.ContactId);

            modelBuilder.Entity<ContactSkill>()
                .HasOne(bc => bc.Skill)
                .WithMany(c => c.ContactSkills)
                .HasForeignKey(bc => bc.SkillId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
