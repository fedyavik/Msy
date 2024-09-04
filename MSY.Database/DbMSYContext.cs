using Microsoft.EntityFrameworkCore;
using MSY.Database.Models;

namespace MSY.Database;

public class DbMSYContext: DbContext
{
    public DbSet<ModuleData> ModulesData { get; set; }
    
    public DbMSYContext(DbContextOptions<DbMSYContext> options) : base(options)
    {
    }
}
