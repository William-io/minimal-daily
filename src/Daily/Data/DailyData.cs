using Daily.Entities;
using Microsoft.EntityFrameworkCore;

namespace Daily.Data
{
    public class DailyData : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");

        public DbSet<DailyAnnotation> Annotations { get; set; }

    }
}
