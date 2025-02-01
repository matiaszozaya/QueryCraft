using QueryCraft.Entities;
using Microsoft.EntityFrameworkCore;

namespace QueryCraft.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Transformation> Transformations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dataset>()
                .HasMany(d => d.Fields)
                .WithOne(f => f.Dataset)
                .HasForeignKey(f => f.DatasetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dataset>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<Transformation>()
                .HasOne(t => t.SelectedDataset)
                .WithMany()
                .HasForeignKey(t => t.SelectedDatasetId);

            modelBuilder.Entity<Transformation>()
                .HasMany(t => t.Operations)
                .WithOne(o => o.Transformation)
                .HasForeignKey(o => o.TransformationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transformation>()
                .HasMany(t => t.SourceFields)
                .WithMany();

            modelBuilder.Entity<Transformation>()
                .HasMany(t => t.ResultFields)
                .WithMany();

            modelBuilder.Entity<Operation>()
                .HasMany(o => o.SourceFields)
                .WithMany();

            modelBuilder.Entity<Operation>()
                .HasMany(o => o.ResultFields)
                .WithMany();
        }
    }
}