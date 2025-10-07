using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Model
{
    internal class Owner
    {
        public int OwnerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
