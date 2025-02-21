using Microsoft.EntityFrameworkCore;

namespace Mission06_Graham.Models;
//Very simple context page :)
public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }
    
    //Added Categories table to the context
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
}