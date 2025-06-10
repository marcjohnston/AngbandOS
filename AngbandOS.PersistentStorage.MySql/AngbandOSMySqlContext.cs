using AngbandOS.PersistentStorage.MySql.Entities;
using Microsoft.EntityFrameworkCore;
namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Encapsulates the connection string needed to access the database entities.
    /// </summary>
    public class AngbandOSMySqlContext : AngbandOSContext
    {
        protected string ConnectionString { get; }

        public AngbandOSMySqlContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ConnectionString);
            }
        }
    }
}
