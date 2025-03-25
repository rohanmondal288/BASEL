using Microsoft.EntityFrameworkCore;

namespace BASEL.Models
{
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options)
        {
        }

        public DbSet<Master> MASTER { get; set; }
        public DbSet<Project> PROJECT { get; set; }

        public DbSet<Circle> CIRCLE { get; set; }

        public DbSet<Site> SITE { get; set; }

        public DbSet<PurchaseDetails> PURCHASE_DETAILS { get; set; }

        //public DbSet<Site>SITE { get; set; }




    }
}
