using Microsoft.EntityFrameworkCore;
using Application.Models;

namespace Application.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
}
