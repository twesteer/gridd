using gridd.Models;
using Microsoft.EntityFrameworkCore;

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options)
        : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Games> Games { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<ReceivedGame> ReceivedGames { get; set; }
    public DbSet<ReceivedAchievement> ReceivedAchievements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>()
            .HasOne(u => u.Country)
            .WithMany()
            .HasForeignKey(u => u.CountryId);

        modelBuilder.Entity<Games>()
            .HasOne(g => g.Company)
            .WithMany(c => c.Games)
            .HasForeignKey(g => g.CompanyId);

        modelBuilder.Entity<Achievement>()
            .HasOne(a => a.Game)
            .WithMany(g => g.Achievements)
            .HasForeignKey(a => a.GameId);

        modelBuilder.Entity<Wallet>()
            .HasOne(w => w.User)
            .WithMany(u => u.Wallets)
            .HasForeignKey(w => w.UserId);


        modelBuilder.Entity<ReceivedGame>()
            .HasOne(rg => rg.User)
            .WithMany(u => u.ReceivedGames)
            .HasForeignKey(rg => rg.UserId);

        modelBuilder.Entity<ReceivedAchievement>()
            .HasOne(ra => ra.Achievement)
            .WithMany()
            .HasForeignKey(ra => ra.AchievementId);

        modelBuilder.Entity<ReceivedAchievement>()
            .HasOne(ra => ra.User)
            .WithMany(u => u.ReceivedAchievements)
            .HasForeignKey(ra => ra.UserId);
    }


}
