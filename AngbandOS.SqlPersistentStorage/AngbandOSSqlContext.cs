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

        public AngbandOSSqlContext(string connectionString) : base(CreateOptions(connectionString))
        {
            ConnectionString = connectionString;
        }

        private static DbContextOptions<AngbandOSContext> CreateOptions(string connectionString)
        {
            return new DbContextOptionsBuilder<AngbandOSContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
