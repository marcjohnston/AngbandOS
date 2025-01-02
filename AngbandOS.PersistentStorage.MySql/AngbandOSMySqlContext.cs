using AngbandOS.PersistentStorage.MySql.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// MySQL-specific DbContext that inherits from <see cref="AngbandOSContext"/> 
    /// to provide a connection to the underlying database using EF Core.
    /// </summary>
    public class AngbandOSMySqlContext : AngbandOSContext
    {
        /// <summary>
        /// Gets the MySQL connection string used to configure this DbContext.
        /// </summary>
        protected string ConnectionString { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AngbandOSMySqlContext"/> class
        /// with the specified connection string.
        /// </summary>
        /// <param name="connectionString">The non-empty MySQL connection string.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="connectionString"/> is null or empty.</exception>
        public AngbandOSMySqlContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "MySQL connection string cannot be null or empty.");
            }

            ConnectionString = connectionString;
        }

        /// <summary>
        /// Configures the DbContext if not already configured,
        /// using the MySQL provider with the supplied connection string.
        /// </summary>
        /// <param name="optionsBuilder">A builder to create or modify options for this context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ConnectionString);

                // Uncomment and modify the following lines for any advanced configurations:
                // optionsBuilder.UseLoggerFactory(myLoggerFactory);
                // optionsBuilder.EnableSensitiveDataLogging();
                // optionsBuilder.CommandTimeout(120); // example: override default command timeout
            }
        }
    }
}
