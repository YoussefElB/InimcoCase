using System.Text.Json.Serialization;

namespace Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //so about this, i can make a class called SocialSkill, and give it an ID and a Name but really this works too.
        //We serialize it into a string to store it in the database, and then deserialize it back into a string array. 
        //sketchy? Could be, but poses no real problem. I've seen smarter people than me use this.
        public string[] SocialSkills { get; set; }
        public IList<SocialAccount> SocialAccounts { get; set; }

        public void AddSocialAccount(SocialAccount sa)
        {
            if (SocialAccounts == null) SocialAccounts = new List<SocialAccount>();
            SocialAccount socialAccount = new SocialAccount()
            {
                Type = sa.Type,
                Address = sa.Address,
                PersonId = this.Id,
                Person = this
            };
            SocialAccounts.Add(sa);
        }
    }
}
