using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MapsGuides.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Dot> Dots { get; set; }
        public DbSet<Msg> Msgs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RegisterService> RegisterServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            contextInitilizer(modelBuilder);

            modelBuilder.Entity<Categorie>()
                .HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.user_id)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.user_id)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dot>()
                .HasOne(d => d.User)
                .WithMany(u => u.Dots)
                .HasForeignKey(d => d.user_id)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dot>()
                .HasOne(d => d.Categorie)
                .WithMany(c => c.Dots)
                .HasForeignKey(d => d.category_id)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.user_id)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Msg>()
                .HasOne(p => p.User)
                .WithMany(u => u.Msgs)
                .HasForeignKey(p => p.user_id)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.RegisterService)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.register_service_id)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        }
        private void contextInitilizer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>().HasData(new Categorie[] {
                new Categorie { id=1,created=DateTime.Now, name = "Продукты" },
                new Categorie { id=2,created=DateTime.Now, name = "Хэндмейд" },
                new Categorie { id=3,created=DateTime.Now, name = "Вещи" },
                new Categorie { id=4,created=DateTime.Now, name = "Услуги" }
            });
            modelBuilder.Entity<RegisterService>().HasData(new RegisterService[] {
                new RegisterService { Id = 1, Name ="SOM"},
                new RegisterService { Id = 2, Name ="Google", ClientID="955437441941-sj9tjud9ofdk2jtarrv5optosoi9f040.apps.googleusercontent.com", ClientSecret="yvn-Afne1n3BQqZOPcXXQoDH"},
                new RegisterService { Id = 3, Name ="Twitter"},
                new RegisterService { Id = 4, Name ="Microsoft"},
                new RegisterService { Id = 5, Name ="Facebook"}
                });
        }
    }
}
