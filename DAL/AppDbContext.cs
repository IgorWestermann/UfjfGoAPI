using Microsoft.EntityFrameworkCore;
using UfjfGoAPI.Domain.Entity;

namespace UfjfGoAPI.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options) { }
        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Evaluation>? Evaluations { get; set; }
        public virtual DbSet<Ride>? Rides { get; set; }
        public virtual DbSet<Message>? Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(false);
                entity.Property(x => x.Email).IsUnicode(false);
                entity.Property(x => x.Password).IsUnicode(false);
                entity.Property(x => x.Matricula).IsUnicode(false);
                entity.Property(x => x.Curso).IsUnicode(false);
                entity.Property(x => x.Phone).IsUnicode(false);
                entity.Property(x => x.Photo).IsUnicode(false);
                entity.Property(x => x.Cnh).IsUnicode(false);
                entity.Property(x => x.User_type_id).IsUnicode(false);
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.Property(x => x.Content).IsUnicode(false);
                entity.Property(x => x.Rate).IsUnicode(false);
                entity.HasOne(x => x.User)
                    .WithMany(y => y.Evaluations)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.Property(x => x.Date).IsUnicode(false);
                entity.Property(x => x.From).IsUnicode(false);
                entity.Property(x => x.Destination).IsUnicode(false);
                entity.Property(x => x.Vagas).IsUnicode(false);
                entity.Property(x => x.OnlyWoman).IsUnicode(false);
                entity.HasOne(x => x.User)
                    .WithMany(y => y.Rides)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
