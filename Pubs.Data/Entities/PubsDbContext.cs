using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pubs.Data.Entities
{
    public partial class PubsDbContext : DbContext
    {
        public virtual DbSet<PubsAuthors> PubsAuthors { get; set; }
        public virtual DbSet<PubsEmployee> PubsEmployee { get; set; }
        public virtual DbSet<PubsJobs> PubsJobs { get; set; }
        public virtual DbSet<PubsPubInfo> PubsPubInfo { get; set; }
        public virtual DbSet<PubsPublishers> PubsPublishers { get; set; }
        public virtual DbSet<PubsSales> PubsSales { get; set; }
        public virtual DbSet<PubsStores> PubsStores { get; set; }
        public virtual DbSet<PubsTitleauthor> PubsTitleauthor { get; set; }
        public virtual DbSet<PubsTitles> PubsTitles { get; set; }
        public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }

        public PubsDbContext(DbContextOptions options) : base(options) { }
        public PubsDbContext() : base() { }

        // Unable to generate entity type for table 'dbo.pubs_discounts'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.pubs_roysched'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PubsAuthors>(entity =>
            {
                entity.HasKey(e => e.AuId)
                    .HasName("UPKCL_auidind");

                entity.HasIndex(e => new { e.AuLname, e.AuFname })
                    .HasName("aunmind");

                entity.Property(e => e.Phone).HasDefaultValueSql("('UNKNOWN')");
            });

            modelBuilder.Entity<PubsEmployee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_emp_id");

                entity.HasIndex(e => new { e.Lname, e.Fname, e.Minit })
                    .HasName("employee_ind");

                entity.Property(e => e.HireDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JobId).HasDefaultValueSql("((1))");

                entity.Property(e => e.JobLvl).HasDefaultValueSql("((10))");

                entity.Property(e => e.PubId).HasDefaultValueSql("('9952')");
            });

            modelBuilder.Entity<PubsJobs>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PK__pubs_job__6E32B6A5A552291F");

                entity.Property(e => e.JobDesc).HasDefaultValueSql("('New Position - title not formalized yet')");
            });

            modelBuilder.Entity<PubsPubInfo>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubinfo");
            });

            modelBuilder.Entity<PubsPublishers>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubind");

                entity.Property(e => e.Country).HasDefaultValueSql("('USA')");
            });

            modelBuilder.Entity<PubsSales>(entity =>
            {
                entity.HasKey(e => new { e.StorId, e.OrdNum, e.TitleId })
                    .HasName("UPKCL_sales");

                entity.HasIndex(e => e.TitleId)
                    .HasName("titleidind");
            });

            modelBuilder.Entity<PubsStores>(entity =>
            {
                entity.HasKey(e => e.StorId)
                    .HasName("UPK_storeid");
            });

            modelBuilder.Entity<PubsTitleauthor>(entity =>
            {
                entity.HasKey(e => new { e.AuId, e.TitleId })
                    .HasName("UPKCL_taind");

                entity.HasIndex(e => e.AuId)
                    .HasName("auidind");

                entity.HasIndex(e => e.TitleId)
                    .HasName("titleidind");
            });

            modelBuilder.Entity<PubsTitles>(entity =>
            {
                entity.HasKey(e => e.TitleId)
                    .HasName("UPKCL_titleidind");

                entity.HasIndex(e => e.Title)
                    .HasName("titleind");

                entity.Property(e => e.Pubdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Type).HasDefaultValueSql("('UNDECIDED')");
            });

            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                    .HasName("PK__sysdiagr__C2B05B6196A680C6");

                entity.HasIndex(e => new { e.PrincipalId, e.Name })
                    .HasName("UK_principal_name")
                    .IsUnique();
            });
        }
    }
}