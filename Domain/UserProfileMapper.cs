using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
 
namespace Domain
{
    public class UserProfileMapper
    {

        public UserProfileMapper(EntityTypeBuilder<UserProfile> entityTypeBuilder)
        {
            //entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.Property(t => t.FirstName).IsRequired();
            entityTypeBuilder.Property(t => t.LastName).IsRequired();
            entityTypeBuilder.Property(t => t.Address).IsRequired();

      //No need to define relationship in dependent table, here profile is dependent only on user.


        }
    }
}
