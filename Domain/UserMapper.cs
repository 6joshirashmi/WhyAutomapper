using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Domain
{
    public class UserMapper
    {
        //Need to define a relationship between multiple tables at this point only.
        public UserMapper(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.Property(t => t.UserName).IsRequired();
            entityTypeBuilder.Property(t => t.Password).IsRequired();
            entityTypeBuilder.Property(t => t.Email).IsRequired();

            //Need to define a relationship between multiple tables at this point only.
            entityTypeBuilder.HasOne(t => t.UserProfile).WithOne(u => u.User).HasForeignKey<UserProfile>(x => x.Id);

        }
    }
}
