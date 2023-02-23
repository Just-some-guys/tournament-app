using Microsoft.EntityFrameworkCore;

namespace TournamentApp.Infrastructure.Persistence;
public class DbInitializer
{
    private readonly TournamentAppContext _context;

    public DbInitializer(TournamentAppContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        await _context.Database.MigrateAsync();
    }
}
