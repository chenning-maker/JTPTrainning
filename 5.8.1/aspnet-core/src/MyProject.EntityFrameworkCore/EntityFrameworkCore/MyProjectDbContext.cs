using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.MultiTenancy;
using MyProject.Sys;

namespace MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sys_Dict_Type> Sys_Dict_Type { get; set; }
        public DbSet<User_Type> User_Type { get; set; }
        public DbSet<Meeting_Type> Meeting_Type{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sys_Dict_Type>(p =>
            {
                p.ToTable("Sys_Dict_Type","test");
                p.Property(x => x.Name).IsRequired(true).HasMaxLength(20);


            });
            modelBuilder.Entity<User_Type>(p =>
            {
                p.ToTable("User_Type", "test");
                p.Property(x => x.Name).IsRequired(true).HasMaxLength(20);


            });

            modelBuilder.Entity<Meeting_Type>(p =>
            {
                p.ToTable("Meeting_Type", "test");
                p.Property(x => x.CreateUserName).IsRequired(true).HasMaxLength(20);


            });
        }
    }
}
