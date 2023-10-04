using Microsoft.EntityFrameworkCore;

namespace Cucina.Persistence.Context
{
    public class CucinaDbContext : DbContext
    {
        public CucinaDbContext(DbContextOptions<CucinaDbContext> options) : base(options) { }
    }
}
