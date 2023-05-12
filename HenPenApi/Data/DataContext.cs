using HenPenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HenPenApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) { }

        public DbSet<Hen> Hens => Set<Hen>();
    }
}
