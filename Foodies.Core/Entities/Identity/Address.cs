using System.ComponentModel.DataAnnotations.Schema;

namespace Foodies.Core.Entities.Identity
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string country, string city, string street)
        {
            Country = country;
            City = city;
            Street = street;
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }


        public string AppUserId { get; set; }
    }
}