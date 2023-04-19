using Application.Dtos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class PersonMapper
    {
        public static PersonDto MapToDto(Person person)
        {
            return new PersonDto
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                SocialSkills = person.SocialSkills,
                SocialAccounts = person.SocialAccounts
            };
        }

        public static Person MapToEntity(PersonDto personDto)
        {
            return new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                SocialSkills = personDto.SocialSkills,
                SocialAccounts = personDto.SocialAccounts
            };
        }
    }
}

