using CustomerControl.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerControl.Data;

public class CostumerContext : DbContext
{
    public DbSet<CostumerModel> Peolpe { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=costumer.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}