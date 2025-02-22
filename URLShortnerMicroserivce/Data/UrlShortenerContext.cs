using System;
using Microsoft.EntityFrameworkCore;
using URLShortnerMicroserivce.Model;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-IBQA4NC;Initial Catalog=URLShortnerServiceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
