using System;
using System.Collections.Generic;
using FluentValidation;
using Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            SocialSkills = new List<string> { "Communication", "Teamwork", "Leadership" },
            SocialAccounts = new List<SocialAccount>
            {
                new SocialAccount { Type = "Twitter", Address = "https://twitter.com/johndoe" },
                new SocialAccount { Type = "LinkedIn", Address = "https://www.linkedin.com/in/johndoe" }
            }
        };
    }
}