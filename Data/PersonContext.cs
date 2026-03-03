using Microsoft.EntityFrameworkCore;
using Person.Routes.Models;

namespace Person.Data;

public class PersonContext : DbContext
{
    public DbSet<PersonModel> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PersonDb;Trusted_Connection=True;");
    }
}