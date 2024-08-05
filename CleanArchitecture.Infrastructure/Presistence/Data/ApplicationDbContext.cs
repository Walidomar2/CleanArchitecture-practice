using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Presistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



    }
}
