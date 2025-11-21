using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
         public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<DailySpecial> DailySpecials => Set<DailySpecial>();
        public DbSet<Table> Tables => Set<Table>();
        public DbSet<ClientSession> ClientSessions => Set<ClientSession>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<OrderEvent> OrderEvents => Set<OrderEvent>();
        public DbSet<OrderNumber> OrderNumbers => Set<OrderNumber>();
        public DbSet<OrderSource> OrderSources => Set<OrderSource>();
        public DbSet<CancellationReason> CancellationReasons => Set<CancellationReason>();
        public DbSet<PrintTicket> PrintTickets => Set<PrintTicket>();
        public DbSet<Coupon> Coupons => Set<Coupon>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<PaymentWebhook> PaymentWebhooks => Set<PaymentWebhook>();
        public DbSet<IdempotencyKey> IdempotencyKeys => Set<IdempotencyKey>();
        public DbSet<Tax> Taxes => Set<Tax>();
        public DbSet<OrderTax> OrderTaxes => Set<OrderTax>();
        public DbSet<RestaurantSettings> RestaurantSettings => Set<RestaurantSettings>();
        public DbSet<RestaurantTheme> RestaurantThemes => Set<RestaurantTheme>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Load all IEntityTypeConfiguration<T> implementations in the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // If you have enums, map them to byte (tinyint):
            // modelBuilder.Entity<Order>().Property(o => o.Status).HasConversion<byte>();
        }

    }
}
