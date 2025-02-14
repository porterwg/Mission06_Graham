using Microsoft.EntityFrameworkCore;

namespace Mission06_Graham.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
}