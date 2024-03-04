using Bot.Configuration;
using FindMosque.Bot.Entity;
using Microsoft.EntityFrameworkCore;

namespace FindMosque.Bot.Data;

public class BotDbContext:DbContext
{
    public BotDbContext(DbContextOptions<BotDbContext> options):base(options)
    {
            
    }

    DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}

