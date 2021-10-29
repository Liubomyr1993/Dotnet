using Dotnet.models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Users> newusers { get; set; }
    }
}