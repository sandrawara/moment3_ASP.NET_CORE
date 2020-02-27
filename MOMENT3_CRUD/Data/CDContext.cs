using Microsoft.EntityFrameworkCore;
using MOMENT3_CRUD.Models;


namespace MOMENT3_CRUD.Data
{
    public class CDContext : DbContext
    {
        public CDContext(DbContextOptions<CDContext> options) : base(options)
        {

        }

        public DbSet<CD> CDs { get; set; }
        public DbSet<Genres> Genres { get; set; }
    }
}

