using Microsoft.EntityFrameworkCore;

namespace PresidentialPolls.Model
{
    public class DBContexts
    {
        public class PollContextFactory
        {
            //private static PollContext instance = null;

            public static string? Path { get; internal set; }

            //public PollContextFactoryy(string filePath) { return n }
            public static PollContext Instance
            {
                get
                {
                    if( Path == null ) throw new ArgumentNullException("path");
                    //instance ??= new PollContext(Path);
                    return new PollContext(Path);
                }
            }
        }

        [Keyless]
        public class PollContext(string filePath) : DbContext
        {
            public DbSet<StatesPollData> Polls { get; set; }
            public DbSet<State> States { get; set; }

            public string DbPath { get; } = System.IO.Path.Join(filePath, "PresidentialPolls.db");

            // The following configures EF to create a Sqlite database file in the
            // special "local" folder for your platform.
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite($"Data Source={DbPath}");

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }

        }

    }

    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }


}
