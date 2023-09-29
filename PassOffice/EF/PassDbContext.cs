using Microsoft.EntityFrameworkCore;
using PassOffice.EF.Configuration;

namespace PassOffice.EF;

public class PassDbContext : DbContext
{
    private static string ConnectionString => @"Data Source = localhost; Initial Catalog = PassOfficeDB; UID=db_user;PWD=db_user1;Encrypt=False;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PassConfiguration());
    }
}