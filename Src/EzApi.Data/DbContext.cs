namespace EzApi.Data;

public class EzDbContext : DbContext
{
    public EzDbContext(DbContextOptions<EzDbContext> options) : base(options)
    {

    }
    public DbSet<AreaTeam>? AreaTeams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Uncomment to watch the EFCore SQL to debut,  comment if going to production
        optionsBuilder.LogTo(Console.WriteLine);
    }
}
