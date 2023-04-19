using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] SocialSkills { get; set; }
        public IList<SocialAccount> SocialAccounts { get; set; }
    }
}
