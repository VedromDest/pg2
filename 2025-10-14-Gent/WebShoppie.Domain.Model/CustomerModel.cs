using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Domain.Model
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string GetFullContactInfo()
        {
            return FirstName + " " + LastName + "<" + Email + ">";
        }
    }
}
