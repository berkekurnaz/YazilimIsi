using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YazilimIsi.Entity.Models
{
    public partial class DbYazilimIsiContext : DbContext
    {
        public DbYazilimIsiContext()
        {
        }

        public DbYazilimIsiContext(DbContextOptions<DbYazilimIsiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountActivity> AccountActivity { get; set; }
        public virtual DbSet<Award> Award { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Portfolio> Portfolio { get; set; }
        public virtual DbSet<Support> Support { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DF3RRQ5;Database=DbYazilimIsi;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountActivity>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Money).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.AccountActivity)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_AccountActivity_Developer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccountActivity)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AccountActivity_Job");
            });

            modelBuilder.Entity<Award>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.Award)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_Award_Developer");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Mail).HasMaxLength(100);

                entity.Property(e => e.NameSurname).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Job).HasMaxLength(50);

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.Mail).HasMaxLength(100);

                entity.Property(e => e.MediaGithub).HasMaxLength(150);

                entity.Property(e => e.MediaLinkedin).HasMaxLength(150);

                entity.Property(e => e.MediaMedium).HasMaxLength(150);

                entity.Property(e => e.MediaWebsite).HasMaxLength(150);

                entity.Property(e => e.Money).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Photo).HasMaxLength(250);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.Education)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_Education_Developer");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Photo).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.ViewCount).HasMaxLength(50);

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.JobNavigation)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_Job_Developer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobNavigation)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Job_User");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Photo).HasMaxLength(200);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Price).HasMaxLength(10);

                entity.Property(e => e.Time).HasMaxLength(10);

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_Offer_Developer");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_Offer_Job");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasMaxLength(50);

                entity.Property(e => e.ProjectName).HasMaxLength(250);

                entity.Property(e => e.ProjectUrl).HasMaxLength(250);

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.Portfolio)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_Portfolio_Developer");
            });

            modelBuilder.Entity<Support>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SupportFile).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Job).HasMaxLength(100);

                entity.Property(e => e.Mail).HasMaxLength(100);

                entity.Property(e => e.Money).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Photo).HasMaxLength(250);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
