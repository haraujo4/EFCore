using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }
    
    public DbSet<Usuario> Usuarios { get; set; }
    
    
}