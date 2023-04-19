using Application.Dtos;
using Application.QueryHandlers;
using Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Reflection.Metadata;

namespace Testing
{
    [TestClass]
    public class PersonUnitTests
    {
        private DbContextOptions<InimcoDbContext> _options;

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<InimcoDbContext>()
                .Options;

            using var context = new InimcoDbContext(_options);
            context.Database.EnsureCreated();
        }

        //Testing some basic functionality of the database
        [TestMethod]
        public async Task AddPerson()
        {
            using var context = new InimcoDbContext(_options);
            var person = new AddPersonDto
            {
                FirstName = "John",
                LastName = "Doe",
                SocialSkills = new string[] { "Facebook", "Twitter" }
            };
            var personId = await context.AddAsync(person);
            var personFromDb = await context.Persons.FindAsync(personId);
            personFromDb.Should().NotBeNull();
            personFromDb.FirstName.Should().Be(person.FirstName);
            personFromDb.LastName.Should().Be(person.LastName);
            personFromDb.SocialSkills.Should().BeEquivalentTo(person.SocialSkills);
        }

    }
}