using System;
using System.Configuration;
using System.Data.Entity;

namespace NewsletterManager.Core.DAL
{
    public interface INewsletterDB: IDisposable
    {
        DbSet<BE.Newsletter> Newsletters { get; set; }
    }

    /// <summary> EntityFramework context class for the NewsletterDB database </summary>
    internal class NewsletterDB : DbContext, INewsletterDB
    {
        public DbSet<BE.Newsletter> Newsletters { get; set; }

        /// <summary> Construct a new context using the specified connection string </summary>
        public NewsletterDB() : base(ConfigurationManager.ConnectionStrings["NewsletterDBConnection"].ConnectionString) { Database.SetInitializer<NewsletterDB>(null); }

        /// <summary> Construct a new context using the specified connection </summary>
        public NewsletterDB(string connectionName) : base(connectionName) { Database.SetInitializer<NewsletterDB>(null); }

        /// <summary> EntityFramework model configuration </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BE.Newsletter>().ToTable("dbo.Newsletter");
        }
    }
}

