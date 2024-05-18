using System;

namespace Domain
{
    public  class UserProfile:BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public User User { get; set; } // For cascade or dependency.. referencial integrity 


    }
}
