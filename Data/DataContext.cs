using Microsoft.EntityFrameworkCore;
using micropay.Models;

namespace micropay.Data;

public class DataContext : DbContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var version = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("server=localhost;database=database;user=root;password=bruno1234;", version);   
    }
    public DbSet<User> Users { get; set; }
}