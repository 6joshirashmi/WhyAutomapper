
using Microsoft.EntityFrameworkCore;

namespace Domain.EFCore;

public class UserDBContext : DbContext
{
    // public UserDBContext(DbContextOptions<UserDBContext> dbContextOptions) : base(dbContextOptions)
    // {

    // }
    public UserDBContext() { }

    #region Case study 1
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=MAHAAN-BHARAT\\MSSQLSERVERS;Database=UserManagement;TrustServerCertificate=true; Integrated security=true; user id=sa; password=1234;");
    }

    //We should not declare the DBSet in Domain Layer.
    //Generic class can be used.

    //public DbSet<User> Users { get; set; }
    //public DbSet<UserProfile> UserProfile { get; set; } 
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Apply associations 
        new UserMapper(modelBuilder.Entity<User>());
        new UserProfileMapper(modelBuilder.Entity<UserProfile>());

        // Applying fluent API
    }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfile { get; set; } 

}

