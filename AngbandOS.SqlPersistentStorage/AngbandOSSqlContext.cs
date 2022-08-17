using AngbandOS.PersistentStorage.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Encapsulates the connection string needed to access the database entities.
    /// </summary>
    public class AngbandOSSqlContext : AngbandOSContext
    {
        protected string ConnectionString { get; }

        public AngbandOSSqlContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
