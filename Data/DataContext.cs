using Microsoft.EntityFrameworkCore;
using micropay.Models;

namespace micropay.Data;

public class DataContext : DbContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var version = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("server=ec2-52-90-110-80.compute-1.amazonaws.com;database=database;user=root;password=bruno1234;", version);   
    }
    public DbSet<User> Users { get; set; }
}