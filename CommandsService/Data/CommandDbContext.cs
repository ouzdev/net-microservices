using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data
{
    public class CommandDbContext : DbContext
    {
        public CommandDbContext(DbContextOptions<CommandDbContext> options):base(options)
        {
            
        }

        public DbSet<Platform> Platforms {get; set; }
        public DbSet<Command> Commands {get; set; }
    }
}