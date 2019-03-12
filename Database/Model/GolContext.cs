using Microsoft.EntityFrameworkCore;

namespace Database.Model
{
    public partial class GolContext : DbContext
    {
        public GolContext()
        {
        }

        public GolContext(DbContextOptions<GolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airplanes> Airplanes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Gol;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplanes>(entity =>
            {
                entity.Property(e => e.Criacao).HasColumnType("datetime");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
