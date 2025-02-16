using Microsoft.EntityFrameworkCore;
using URLShortnerMicroserivce.Model;

namespace URLShortnerMicroserivce.Data
{
    /// <summary>
    /// Database context class for CRUD operation on DB using EF.
    /// </summary>
    public class UrlShortenerContext : DbContext
    {
        /// <summary>
        /// Represents the UrlMappings table in the database.
        /// </summary>
        public DbSet<UrlMapping> UrlMappings { get; set; }

        /// <summary>
        /// This will configure the database engine used for DbContext.
        /// </summary>
        /// <param name="optionsBuilder">Instace of DbContextOptionsBuilder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-IBQA4NC;Initial Catalog=UrlShortnerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
