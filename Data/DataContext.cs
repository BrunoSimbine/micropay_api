using Microsoft.EntityFrameworkCore;
using micropay.Models;

namespace micropay.Data;

public class DataContext : DbContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var version = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("server=3.94.197.194;database=mydb;user=bruno;password=Bruno@123456789/@Senha09;", version);   
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Phone)
            .IsUnique();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}