using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class PortManagementContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PortManagement;Trusted_Connection=true");

        }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<CheckIn> CheckIn { get; set; }
        public DbSet<CheckOut> CheckOut { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<Port> Port { get; set; }
        public DbSet<Ship> Ship { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<WareHouse> WareHouse { get; set; }
        public DbSet<Working> Working { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
