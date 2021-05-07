using ComputerisedAssingment.ModelEntity;
using Microsoft.EntityFrameworkCore;

namespace ComputerisedAssingment.ModelsEntity
{
    public class AppDBContext : DbContext
    {
        public static string ConnectionString { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }

        public AppDBContext()
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<AssingStudents> AssingStudents { get; set; }
        public virtual DbSet<TeacherUpload> TeacherUpload { get; set; }
        public virtual DbSet<StudentUpload> StudentUpload { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}