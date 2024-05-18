using System;

namespace Domain
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //public UserProfile? Profile { get; set; } // Navigation ***Important, this is 1-1 relationship // navigation should be based on virtual keyword
        public UserProfile UserProfile { get; set; }
    }
}
